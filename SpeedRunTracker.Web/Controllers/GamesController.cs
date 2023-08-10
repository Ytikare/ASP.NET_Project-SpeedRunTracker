using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Interfaces;
using SpeedRunTracker.Services.Models;

namespace SpeedRunTracker.Web.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly IGameService gameService;

        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
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

            if (await gameService.DoesCategoryExistsAsync(categoryId) == false)
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
    }
}
