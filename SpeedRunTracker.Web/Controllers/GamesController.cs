using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Interfaces;
using SpeedRunTracker.Services.Models;

namespace SpeedRunTracker.Web.Controllers
{
    [Authorize(Roles = "Moderator, Admin")]
    public class GamesController : Controller
    {
        private readonly IGameService gameService;
        private readonly ICategoryService categoryService;
        private readonly IGenreService genreService;

        public GamesController(IGameService gameService, 
            ICategoryService categoryService, 
            IGenreService genreService)
        {
            this.gameService = gameService;
            this.categoryService = categoryService;
            this.genreService = genreService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Browse([FromQuery]BrowseGamesQueryModel queryModel)
        {
            AllGamesSortedServiceModel servModel = await gameService.AllGamesAsync(queryModel);

            queryModel.Games = servModel.Games;
            queryModel.TotalGames = servModel.TotalGames;

            return View(queryModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Leaderboard(int gameId, int categoryId)
        {
            if (await gameService.DoesGameExistsAsync(gameId) == false)
            {
                return NotFound();
            }

            if (await categoryService.DoesCategoryExistsByIdAsync(categoryId) == false)
            {
                return NotFound();
            }

            if (await gameService.DoesGameContaionsCategoryAsync(gameId, categoryId) == false)
            {
                return NotFound();
            }


            var model = await gameService.GetLeaderboardDataAsync(gameId, categoryId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add() 
        {
            GameFormModel model = new GameFormModel()
            {
                CategoryNames = await categoryService.GetAllCategoryNamesAsync(),
                GenreTypes = await genreService.GetAllGenreTypesAsync()
            };

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Add(GameFormModel model)
        {
            if (await categoryService.CheckIfArrayContainsInvalidCategoriesAsync(model.UnmodifiedCategoryString.Split(",", StringSplitOptions.RemoveEmptyEntries)))
            {
                ModelState.AddModelError(nameof(model.UnmodifiedCategoryString), "Invalid category detected. Please input valid categories");
            }

            if (await genreService.CheckIfArrayContainsInvalidGenresAsync(model.UnmodifiedGenreString.Split(',', StringSplitOptions.RemoveEmptyEntries)))
            {
                ModelState.AddModelError(nameof(model.UnmodifiedGenreString), "Invalid genre detected. Please input valid genres");
            }

            if (ModelState.IsValid == false)
            {
                model.CategoryNames = await categoryService.GetAllCategoryNamesAsync();
                model.GenreTypes = await genreService.GetAllGenreTypesAsync();
                
                return View(model);
            }

            try
            {
                await gameService.AddGameAsync(model);
                return RedirectToAction("Browse", "Games");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unpexpected error occured. Please try again.");

                model.CategoryNames = await categoryService.GetAllCategoryNamesAsync();
                model.GenreTypes = await genreService.GetAllGenreTypesAsync();

                return View(model);
            }
        }
    }
}
