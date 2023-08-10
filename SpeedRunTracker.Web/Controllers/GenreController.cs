using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;
using System.Data;

namespace SpeedRunTracker.Web.Controllers
{
    [Authorize(Roles = "Moderator, Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(GenreFormModel model)
        {
            if (await genreService.DoesGenreExistsAsync(model.GenreType))
            {
                ModelState.AddModelError(nameof(model.GenreType), "Category already exists.");
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            try
            {
                await genreService.AddGenreAsync(model);
                return RedirectToAction("Dashboard", "Modetaion");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured. Please try again or contact support.");
                return View(model);
            }


        }
    }
}
