using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Models;
using Horizons.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using static Horizons.Common.ValidationConstants;

namespace Horizons.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly ApplicationDbContext context;

        public DestinationService(ApplicationDbContext appDbContext)
        {
            context = appDbContext;
        }

        public async Task AddDestinationAsync(DestinationAddViewModel destination, string userId)
        {
            string dateTimeString = $"{destination.PublishedOn}";

            if (!DateTime.TryParseExact(dateTimeString, DestinationPublishedDateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDateTime))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            var destinationToAdd = new Destination()
            {
                Name = destination.Name,
                Description = destination.Description,
                ImageUrl = destination.ImageUrl,
                PublisherId = userId,
                PublishedOn = parseDateTime,
                TerrainId = destination.TerrainId,
                IsDeleted = false,
            };

            await context.Destinations.AddAsync(destinationToAdd);
            await context.SaveChangesAsync();
        }

        public async Task AddDestinationToFavoriteAsync(string userId, Destination destination)
        {
            bool isAlreadyAdded = await context.UserDestinations
                .AnyAsync(ud => ud.UserId == userId && ud.DestinationId == destination.Id);

            if (isAlreadyAdded)
            {
                return;
            }

            UserDestination destinationClient = new UserDestination
            {
                UserId = userId,
                DestinationId = destination.Id
            };

            context.Destinations.Update(destination);

            await context.UserDestinations.AddAsync(destinationClient);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DestinationAddToFavoriteViewModel>> AllFavoriteAsync(string userId)
        {
            return await context.UserDestinations
               .Where(d => d.UserId == userId)
               .Select(d => new DestinationAddToFavoriteViewModel
               {
                   Id = d.Destination.Id,
                   Name = d.Destination.Name,
                   Terrain = d.Destination.Terrain.Name,
                   ImageUrl = d.Destination.ImageUrl,
               })
               .ToListAsync();
        }

        public Task DeleteDestinationAsync(Destination destination)
        {
            destination.IsDeleted = true;
            context.Destinations.Update(destination);
            return context.SaveChangesAsync();
        }

        public async Task EditDestinationAsync(DestinationEditViewModel model, Destination destination)
        {
            string dateTimeString = $"{model.PublishedOn}";

            if (!DateTime.TryParseExact(dateTimeString, DestinationPublishedDateFormat, CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out DateTime parseDateTime))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            destination.Name = model.Name;
            destination.Description = model.Description;
            destination.ImageUrl = model.ImageUrl;
            destination.PublishedOn = parseDateTime;
            destination.TerrainId = model.TerrainId;

            await context.SaveChangesAsync();
        }

        public async Task<DestinationAddViewModel> GetAddModelAsync()
        {

            var terrains = await context.Terrains
                .Select(t => new TerrainViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();

            var model = new DestinationAddViewModel
            {
                Terrains = terrains
            };

            return model;
        }

        public async Task<IEnumerable<DestinationAllViewModel>> GetAllAsync(string userId)
        {
            return await context.Destinations
                .Where(d => d.IsDeleted == false)
                .Select(d => new DestinationAllViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Terrain = d.Terrain.Name,
                    ImageUrl = d.ImageUrl,
                    IsPublisher = d.PublisherId == userId,
                    IsFavorite = d.UsersDestinations.Any(ud => ud.UserId == userId && ud.DestinationId == d.Id),
                    FavoritesCount = d.UsersDestinations.Select(ud => ud.DestinationId == d.Id).Count()
                })
                .ToListAsync();
        }

        public async Task<Destination> GetDestinationByIdAsync(int id)
        {
            return await context.Destinations
               .Include(d => d.Publisher)
               .Include(d => d.Terrain)
               .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<DestinationDetailsViewModel> GetDestinationDetails(int destinationId, string userId)
        {
            DestinationDetailsViewModel? destination = await context.Destinations
               .Where(d => d.Id == destinationId)
               .Select(d => new DestinationDetailsViewModel
               {
                   Id = d.Id,
                   Name = d.Name,
                   Description = d.Description,
                   ImageUrl = d.ImageUrl,
                   PublishedOn = d.PublishedOn.ToString(DestinationPublishedDateFormat),
                   Terrain = d.Terrain.Name,
                   Publisher = d.Publisher.Email ?? string.Empty,
                   PublisherId = d.PublisherId,
                   IsFavorite= d.UsersDestinations.Any(ud => ud.UserId == userId && ud.DestinationId == d.Id),
               })
               .FirstOrDefaultAsync();

            return destination;
        }

        public async  Task<DestinationEditViewModel> GetEditModelAsync(int id)
        {
            var terrains = await context.Terrains
               .Select(t => new TerrainViewModel
               {
                   Id = t.Id,
                   Name = t.Name
               })
               .ToListAsync();

            var destination = await context.Destinations
                .Where(d => d.Id == id)
                .Select(d => new DestinationEditViewModel
                {
                    Name = d.Name,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    PublishedOn = d.PublishedOn.ToString(DestinationPublishedDateFormat),
                    TerrainId = d.TerrainId,
                    Terrains = terrains,
                    PublisherId = d.PublisherId,
                })
                .FirstOrDefaultAsync();

            return destination;
        }

        public async Task RemoveDestinationFromFavoriteAsync(string userId, Destination destination)
        {
            var sellerdestination = await context.UserDestinations
                .FirstOrDefaultAsync(ud => ud.UserId == userId && ud.DestinationId == destination.Id);

            if (sellerdestination != null)
            {
                context.Destinations.Update(destination);
                context.UserDestinations.Remove(sellerdestination);
                await context.SaveChangesAsync();
            }
        }
    }
}
