using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;

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
    }
}
