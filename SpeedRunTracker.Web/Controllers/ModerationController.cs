using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Web.Controllers
{
    [Authorize(Roles = "Moderator, Admin")]
    public class ModerationController : Controller
    {
        private readonly IUserService userService;
        private readonly ISpeedRunService speedRunService;
        private readonly ITicketService ticketService;

        public ModerationController(IUserService userService, 
            ISpeedRunService speedRunService, 
            ITicketService ticketService)
        {
            this.userService = userService;
            this.speedRunService = speedRunService;
            this.ticketService = ticketService;
        }

        public async Task<IActionResult> Dashboard()
        {
            DashboardViewModel model = new DashboardViewModel()
            {
                SpeedRuns = await speedRunService.GetOldestFiveUnverifiedSpeedRunsAsync(),
                SupportTickets = await ticketService.GetOldestFiveActiveTicketsAsync()
            };



            return View(model);
        }

        [HttpGet]
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
        public async Task<IActionResult> Disqualify(string speedRunId)
        {
            SpeedRunDisqualifyModel viewModel = new SpeedRunDisqualifyModel()
            {
                SpeedRunDetails = await speedRunService.GetSpeedRunDetailsAsync(speedRunId),
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Disqualify(SpeedRunDisqualifyModel model,string speedRunId)
        {
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
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
    }
}
