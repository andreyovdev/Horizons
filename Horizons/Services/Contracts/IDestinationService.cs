using Horizons.Data.Models;
using Horizons.Models;

namespace Horizons.Services.Contracts
{
    public interface IDestinationService
    {
        Task AddDestinationAsync(DestinationAddViewModel destination, string userId);
        Task AddDestinationToFavoriteAsync(string userId, Destination destination);
        Task<IEnumerable<DestinationAllViewModel>> GetAllAsync(string userId);
        Task<IEnumerable<DestinationAddToFavoriteViewModel>> AllFavoriteAsync(string userId);
        Task<DestinationAddViewModel> GetAddModelAsync();
        Task<Destination> GetDestinationByIdAsync(int id);
        Task<DestinationEditViewModel> GetEditModelAsync(int id);
        Task EditDestinationAsync(DestinationEditViewModel model, Destination destination);
        Task RemoveDestinationFromFavoriteAsync(string userId, Destination destination);
        Task<DestinationDetailsViewModel> GetDestinationDetails(int destinationId, string userId);
        Task DeleteDestinationAsync(Destination destination);
    }
}
