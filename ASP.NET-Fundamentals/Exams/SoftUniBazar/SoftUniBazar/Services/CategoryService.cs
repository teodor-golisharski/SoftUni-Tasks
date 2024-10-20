namespace SoftUniBazar.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoftUniBazar.Contracts;
    using SoftUniBazar.Data;
    using SoftUniBazar.Models.ViewModels;

    public class CategoryService : ICategoryService
    {
        public readonly BazarDbContext dbContext;

        public CategoryService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<CategoryViewModel>> GetAllCategoriesAsync()
        {
            ICollection<CategoryViewModel> categories = await dbContext
                .Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            return categories;
        }
    }
}
