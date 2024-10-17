using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task AddEventToCollection(string userId, EventViewModel model)
        {
            bool alreadyAdded = await context.EventsParticipants
                .AnyAsync(x => x.HelperId == userId && x.EventId == model.Id);

            if (!alreadyAdded)
            {
                var ep = new EventsParticipant
                {
                    EventId = model.Id,
                    HelperId = userId
                };

                await context.EventsParticipants.AddAsync(ep);
                await context.SaveChangesAsync();
            }

        }

        public async Task<DetailsViewModel> GetEventDetailsAsync(int id)
        {
            return await context.Events
                .Where(x => x.Id == id)
                .Select(e => new DetailsViewModel
                {
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    End = e.End.ToString("yyyy-MM-dd H:mm"),
                    Organiser = e.Organiser.UserName,
                    CreatedOn = e.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name
                }).FirstAsync();
        }

        public async Task<IEnumerable<AllEventViewModel>> GetAllEventAsync()
        {
            return await context
                .Events
                .Select(e => new AllEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                }).ToListAsync();
        }

        public async Task AddEventAsync(AddEventViewModel model, string id)
        {
            Event @event = new Event
            {
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                CreatedOn = DateTime.UtcNow,
                OrganiserId = id
            };

            await context.Events.AddAsync(@event);
            await context.SaveChangesAsync();
        }

        public async Task<AddEventViewModel> GetNewAddEventModelAsync()
        {
            var types = await context.Types
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToListAsync();

            var model = new AddEventViewModel
            {
                Types = types,
            };

            return model;
        }

        public async Task<EventViewModel?> GetEventByIdAsync(int id)
        {
            var eventViewModel = await context.Events
                .Where(x => x.Id == id)
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    OrganiserId = e.Organiser.Id,
                    CreatedOn = e.CreatedOn,
                    TypeId = e.Type.Id
                }).FirstOrDefaultAsync();

            return eventViewModel;
        }

        public async Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await context
               .EventsParticipants
               .Where(x => x.HelperId == userId)
               .Select(x => new AllEventViewModel
               {
                   Id = x.Event.Id,
                   Name = x.Event.Name,
                   Type = x.Event.Type.Name,
                   Start = x.Event.Start.ToString("yyyy-MM-dd H:mm")
               }).ToListAsync();
        }

        public async Task RemoveEventFromCollectionAsync(EventViewModel ev, string userId)
        {
            var eventPart = await context.EventsParticipants
                .FirstOrDefaultAsync(x => x.HelperId == userId && ev.Id == x.EventId);

            if (eventPart != null)
            {
                context.EventsParticipants.Remove(eventPart);
                await context.SaveChangesAsync();
            }

        }

        public async Task EditEventAsync(AddEventViewModel model, int id)
        {
            var ev = await context.Events.FindAsync(id);

            if (ev != null)
            {
                ev.Name = model.Name; 
                ev.Description = model.Description;
                ev.Start = model.Start;
                ev.End = model.End;
                ev.TypeId = model.TypeId;

                await context.SaveChangesAsync();
            }
        }

        public async Task<AddEventViewModel> GetAddEventByIdAsync(int id)
        {
            var types = await context.Types
                .Select(t => new TypeViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToListAsync();

            var eventViewModel = await context.Events
                .Where(x => x.Id == id)
                .Select(e => new AddEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    TypeId = e.Type.Id,
                    Types = types
                }).FirstOrDefaultAsync();

            return eventViewModel;
        }
    }
}
