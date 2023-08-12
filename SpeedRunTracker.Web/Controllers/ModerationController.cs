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
        private readonly ISpeedRunService speedRunService;
        private readonly ITicketService ticketService;
        private readonly IUserService userService;

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Moderators()
        {
            var model = await userService.GetModeratorsAsync();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddMod()
        {
            ModeratorFormModel model = new ModeratorFormModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddMod(ModeratorFormModel model)
        {
            if (await userService.CheckIfUserIdExitsasync(model.Id) == false)
            {
                ModelState.AddModelError(nameof(model.Id), "User does not exists.");
            }

            if (await userService.IsUserAModAsync(model.Id))
            {
                ModelState.AddModelError("", "User is already a moderator.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await userService.MakeModeratorAsync(model.Id);
                return RedirectToAction("Moderators", "Moderation");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unexpected error occured. Please try again.");
                return View(model);
            }

        }


        [HttpGet]
        [Authorize( Roles = "Admin")]
        public async Task<IActionResult> RemoveMod(string modUserId)
        {
            if (await userService.CheckIfUserIdExitsasync(modUserId) == false)
            {
                return NotFound();
            }

            if (await userService.IsUserAModAsync(modUserId) == false)
            {
                return NotFound();
            }

            try
            {
                await userService.RemoveModeratorAsync(modUserId);
                return RedirectToAction("Moderators", "Moderation");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
