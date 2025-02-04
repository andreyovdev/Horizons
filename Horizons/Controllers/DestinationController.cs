using Horizons.Data.Models;
using Horizons.Models;
using Horizons.Services;
using Horizons.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Horizons.Controllers
{
    public class DestinationController:BaseController
    {
        private readonly IDestinationService service;

        public DestinationController(IDestinationService dService)
        {
            service = dService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            DestinationAddViewModel model = await service.GetAddModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DestinationAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Terrains = (await service.GetAddModelAsync()).Terrains;

                return View(model);
            }

            string userId = GetUserId();
            await service.AddDestinationAsync(model, userId);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string userId = GetUserId();
            var model = await service.GetAllAsync(userId);
            return View(model);
        }

        public async Task<IActionResult> AddToFavorites(int id)
        {
            Destination destination = await service.GetDestinationByIdAsync(id);

            if (destination == null)
            {
                return BadRequest();
            }
            var userId = GetUserId();

            await service.AddDestinationToFavoriteAsync(userId, destination);
            return RedirectToAction(nameof(Favorites));
        }

        public async Task<IActionResult> Favorites()
        {
            var userId = GetUserId();
            var models = await service.AllFavoriteAsync(userId);

            
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            DestinationEditViewModel model = await service.GetEditModelAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (model.PublisherId != userId)
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DestinationEditViewModel model)
        {
            var destination = await service.GetDestinationByIdAsync(id);

            if (destination == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (destination.PublisherId != userId)
            {
                return Unauthorized();
            }

            await service.EditDestinationAsync(model, destination);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            var destination = await service.GetDestinationByIdAsync(id);

            if (destination == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            await service.RemoveDestinationFromFavoriteAsync(userId, destination);

            return RedirectToAction(nameof(Favorites));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            string userId = GetUserId();
            DestinationDetailsViewModel destiantion = await service.GetDestinationDetails(id, userId);

            if (destiantion == null)
            {
                return BadRequest();
            }

            return View(destiantion);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var destination = await service.GetDestinationByIdAsync(id);

            if (destination == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (destination.PublisherId != userId)
            {
                return Unauthorized();
            }

            DestinationDeleteViewModel model = new DestinationDeleteViewModel
            {
                Id = id,
                Name = destination.Name,
                Publisher = destination.Publisher.Email ?? string.Empty,
                PublisherId = destination.PublisherId,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DestinationDeleteViewModel model)
        {
            var destiantion = await service.GetDestinationByIdAsync(id);

            if (destiantion == null)
            {
                return BadRequest();
            }

            await service.DeleteDestinationAsync(destiantion);

            return RedirectToAction("Index", "Home");
        }
    }
}
