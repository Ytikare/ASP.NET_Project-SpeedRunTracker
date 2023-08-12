using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Web.Controllers
{
    [Authorize(Roles ="Moderator, Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(CategoryFormModel model)
        {
            if (await categoryService.DoesCategoryExistsByNameAsync(model.CategoryName))
            {
                ModelState.AddModelError(nameof(model.CategoryName), "Category already exists.");
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            try
            {
                await categoryService.CreateCategoryAsync(model);
                return RedirectToAction("Browse", "Games");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured. Please try again or contact support.");
                return View(model);
            }


        }
    }
}
