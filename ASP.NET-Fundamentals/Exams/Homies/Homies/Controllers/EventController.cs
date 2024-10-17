using Homies.Contracts;
using Homies.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService service)
        {
            this.eventService = service;
        }

        public async Task<IActionResult> All()
        {
            var model = await eventService.GetAllEventAsync();

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await eventService.GetEventDetailsAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddEventViewModel model = await eventService.GetNewAddEventModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await eventService.AddEventAsync(model, GetUserId());

            return RedirectToAction(nameof(Join));
        }

        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var model = await eventService.GetJoinedEventsAsync(userId);

            return View(model);
        }

        public async Task<IActionResult> Join(int id)
        {
            var ev = await eventService.GetEventByIdAsync(id);

            if (ev == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();

            await eventService.AddEventToCollection(userId, ev);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var ev = await eventService.GetEventByIdAsync(id);

            if (ev == null)
            {
                return RedirectToAction(nameof(Joined));
            }

            var userId = GetUserId();

            await eventService.RemoveEventFromCollectionAsync(ev, userId);

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ev = await eventService.GetAddEventByIdAsync(id);

            if (ev == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(ev);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddEventViewModel model)
        {
            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            await eventService.EditEventAsync(model, id);

            return RedirectToAction(nameof(All));
        }
    }
}
