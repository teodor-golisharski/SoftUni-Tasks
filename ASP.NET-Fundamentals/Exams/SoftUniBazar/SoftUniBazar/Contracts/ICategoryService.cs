namespace SoftUniBazar.Contracts
{
    using SoftUniBazar.Models.ViewModels;

    public interface ICategoryService
    {
        Task<ICollection<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
