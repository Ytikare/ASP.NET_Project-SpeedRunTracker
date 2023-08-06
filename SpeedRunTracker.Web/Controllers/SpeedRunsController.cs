using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Interfaces;
using SpeedRunTracker.Web.Infrastructure.Extensions;
using SpeedRunTracker.Common;

namespace SpeedRunTracker.Web.Controllers
{
    [Authorize]
    public class SpeedRunsController : Controller
    {
        private readonly ISpeedRunService speedRunService;
        private readonly IGameService gameService;
        private readonly ICategoryService categoryService;

        public SpeedRunsController(ISpeedRunService speedRunService,
            IGameService gameService,
            ICategoryService categoryService)
        {
            this.speedRunService = speedRunService;
            this.gameService = gameService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Submit() => View(new SpeedRunFormModel());

        [HttpPost]
        public async Task<IActionResult> Submit(SpeedRunFormModel model)
        {
            if (model.CategoryId == 0)
            {
                ModelState.AddModelError(nameof(model.CategoryId),"Please select a speed run category.");
            }

            if (model.GameId == 0)
            {
                ModelState.AddModelError(nameof(model.GameId), "Please select a game title.");
            }

            if (await gameService.IsGameIdValidAsync(model.GameId) == false)
            {
                ModelState.AddModelError(nameof(model.GameId), "Please select a valid game title.");
            }

            if (await categoryService.IsCategoryIdValid(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Please select a valid speed run category.");
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            try
            {
                await speedRunService.AddSpeedRunAsync(model, User.GetId()!);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string speedRunId)
        {
            if (await speedRunService.CheckSpeedRunExitsAsync(speedRunId))
            {
                SpeedRunDetailsViewModel model = await speedRunService.GetSpeedRunDetailsAsync(speedRunId);

                return View(model);
            }

            return NotFound();

        }
    }
}
