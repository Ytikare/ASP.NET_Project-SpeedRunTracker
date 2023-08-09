using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Interfaces;
using System.Diagnostics;

namespace SpeedRunTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISpeedRunService speedRunService;

        public HomeController(ILogger<HomeController> logger, ISpeedRunService speedRunService)
        {
            _logger = logger;
            this.speedRunService = speedRunService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await speedRunService.GetLatestVerifiedSpeedRunsAsync();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}