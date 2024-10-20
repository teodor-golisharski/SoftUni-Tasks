namespace SoftUniBazar.Services
{
    using Microsoft.EntityFrameworkCore;
    using SoftUniBazar.Contracts;
    using SoftUniBazar.Data;
    using SoftUniBazar.Data.Models;
    using SoftUniBazar.Models.ViewModels;

    public class AdService : IAdService
    {
        public readonly BazarDbContext dbContext;

        public AdService(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAdAsync(AdViewModel model, string id)
        {
            Ad ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                CreatedOn = DateTime.UtcNow,
                ImageUrl = model.ImageUrl,
                OwnerId = id,
                Price = model.Price
            };

            await dbContext.AddAsync(ad);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<AllAdsViewModel>> GetAllAdsAsync()
        {
            ICollection<AllAdsViewModel> allAds = await dbContext
                .Ads
                .Select(a => new AllAdsViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    CreatedOn = a.CreatedOn.ToString("dd-MM-yyyy H:mm"),
                    Category = a.Category.Name,
                    Description = a.Description,
                    Price = a.Price,
                    Seller = a.Owner.UserName
                })
                .ToListAsync();

            return allAds;
        }

        public async Task<AdViewModel> GetNewAdViewModelAsync(ICollection<CategoryViewModel> categories)
        {
            await Task.Yield();

            AdViewModel viewModel = new AdViewModel()
            {
                Categories = categories
            };

            return viewModel;
        }

        public async Task<AdViewModel> GetAdViewModelByIdAsync(int id, ICollection<CategoryViewModel> categories)
        {
            AdViewModel model = await dbContext
                .Ads
                .Select(a => new AdViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    CategoryId = a.CategoryId,
                    Price = a.Price,
                    Description = a.Description,
                    Categories = categories
                })
                .FirstAsync(a => a.Id == id);

            return model;
        }

        public async Task EditAddAsync(AdViewModel model, int id)
        {
            Ad? ad = await dbContext.Ads.FindAsync(id);

            if (ad != null)
            {
                ad.Name = model.Name;
                ad.ImageUrl = model.ImageUrl;
                ad.CategoryId = model.CategoryId;
                ad.Price = model.Price;
                ad.Description = model.Description;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<AllAdsViewModel>> GetMyCart(string id)
        {
            ICollection<AllAdsViewModel> model = await dbContext
                .AdsBuyers
                .Where(ab => ab.BuyerId == id)
                .Select(ab => new AllAdsViewModel
                {
                    Id = ab.AdId,
                    Name = ab.Ad.Name,
                    ImageUrl = ab.Ad.ImageUrl,
                    CreatedOn = ab.Ad.CreatedOn.ToString("dd-MM-yyyy H:mm"),
                    Category = ab.Ad.Category.Name,
                    Description = ab.Ad.Description,
                    Price = ab.Ad.Price,
                })
                .ToListAsync();

            return model;
        }

        public async Task<bool> AdExistsById(int id)
        {
            return await dbContext
                .Ads
                .AnyAsync(a => a.Id == id);
        }

        public async Task AddAdToCollection(string userId, int id)
        {
            AdBuyer adBuyer = new AdBuyer()
            {
                AdId = id,
                BuyerId = userId,
            };

            await dbContext.AddAsync(adBuyer);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAdFromCollection(string userId, int id)
        {
            var ad = await dbContext.AdsBuyers
                .FirstOrDefaultAsync(x => x.BuyerId == userId && x.AdId == id);

            if (ad != null)
            {
                dbContext.AdsBuyers.Remove(ad);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> IsAdAlreadyAddedToCollection(string userId, int id)
        {
            return await dbContext
                .AdsBuyers
                .AnyAsync(x => x.BuyerId == userId && x.AdId == id);
        }
    }
}
