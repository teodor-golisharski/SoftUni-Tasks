namespace SoftUniBazar.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SoftUniBazar.Contracts;
    using SoftUniBazar.Models.ViewModels;

    [Authorize]
    public class AdController : BaseController
    {
        private readonly IAdService adService;
        private readonly ICategoryService categoryService;

        public AdController(IAdService adService, ICategoryService categoryService)
        {
            this.adService = adService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ICollection<AllAdsViewModel> model = await adService.GetAllAdsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ICollection<CategoryViewModel> categories = await categoryService.GetAllCategoriesAsync();

            AdViewModel model = await adService.GetNewAdViewModelAsync(categories);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await adService.AddAdAsync(model, GetUserId());

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ICollection<CategoryViewModel> categories = await categoryService.GetAllCategoriesAsync();

            AdViewModel model = await adService.GetAdViewModelByIdAsync(id, categories);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await adService.EditAddAsync(model, id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string id = GetUserId();

            ICollection<AllAdsViewModel> model = await adService.GetMyCart(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            bool adExist = await adService.AdExistsById(id);

            if (!adExist)
            {
                return RedirectToAction(nameof(All));
            }

            string userId = GetUserId();

            bool alreadyAdded = await adService.IsAdAlreadyAddedToCollection(userId, id);

            if(alreadyAdded)
            {
                return RedirectToAction(nameof(All));
            }

            await adService.AddAdToCollection(userId, id);

            return RedirectToAction(nameof(Cart));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            bool adExist = await adService.AdExistsById(id);

            if (!adExist)
            {
                return RedirectToAction(nameof(All));
            }

            string userId = GetUserId();

            await adService.RemoveAdFromCollection(userId, id);

            return RedirectToAction(nameof(All));
        }
    }
}
