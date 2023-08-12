using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Interfaces;
using SpeedRunTracker.Web.Infrastructure.Extensions;

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
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unpexpected error occured. Please try again later or contact support.");
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

        
        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> Verify(string speedRunId)
        {
            if (await speedRunService.CheckSpeedRunExitsAsync(speedRunId) == false)
            {
                return NotFound();
            }

            try
            {
                await speedRunService.VerifySpeedRunAsync(speedRunId, User.Identity!.Name!);
                return RedirectToAction("Details", "SpeedRuns", new { speedRunId });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> Disqualify(string speedRunId)
        {
            if (await speedRunService.CheckSpeedRunExitsAsync(speedRunId) == false)
            {
                return NotFound();
            }

            SpeedRunDisqualifyModel model = new()
            {
                SpeedRunDetails = await speedRunService.GetSpeedRunDetailsAsync(speedRunId)
            };
            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> Disqualify(SpeedRunDisqualifyModel model, string speedRunId)
        {
            if (await speedRunService.CheckSpeedRunExitsAsync(speedRunId) == false)
            {
                return NotFound();
            }

            if (ModelState.IsValid == false)
            {
                model.SpeedRunDetails = await speedRunService.GetSpeedRunDetailsAsync(speedRunId);
                return View(model);
            }

            try
            {
                await speedRunService.DisqualifySpeedRunAsync(model, speedRunId);
                return RedirectToAction("Details", "SpeedRuns", new { speedRunId });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
