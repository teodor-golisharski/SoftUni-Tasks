namespace SoftUniBazar.Contracts
{
    using SoftUniBazar.Models.ViewModels;

    public interface IAdService
    {
        Task<ICollection<AllAdsViewModel>> GetAllAdsAsync();
        Task<AdViewModel> GetNewAdViewModelAsync(ICollection<CategoryViewModel> categories);
        Task AddAdAsync(AdViewModel model, string id);
        Task<AdViewModel> GetAdViewModelByIdAsync(int id, ICollection<CategoryViewModel> categories);
        Task EditAddAsync(AdViewModel model, int id);
        Task<ICollection<AllAdsViewModel>> GetMyCart(string id);
        Task<bool> AdExistsById(int id);
        Task AddAdToCollection(string userId, int id);
        Task RemoveAdFromCollection(string userId, int id);
        Task<bool> IsAdAlreadyAddedToCollection(string userId, int id);
    }
}
