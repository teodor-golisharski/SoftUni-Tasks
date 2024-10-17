using Homies.Data.Models;
using Homies.Models.ViewModels;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventAsync();

        Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId);
    
        Task AddEventAsync(AddEventViewModel viewModel, string id);

        Task<AddEventViewModel> GetNewAddEventModelAsync();

        Task<DetailsViewModel> GetEventDetailsAsync(int id);

        Task AddEventToCollection(string userId, EventViewModel model);

        Task<EventViewModel> GetEventByIdAsync(int id);

        Task<AddEventViewModel> GetAddEventByIdAsync(int id);

        Task RemoveEventFromCollectionAsync(EventViewModel ev, string userId);

        Task EditEventAsync(AddEventViewModel model, int id);
    }
}
