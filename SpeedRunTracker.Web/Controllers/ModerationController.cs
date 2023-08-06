using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Web.Controllers
{
    [Authorize(Roles = "Moderator, Admin")]
    public class ModerationController : Controller
    {
        private readonly ISpeedRunService speedRunService;
        private readonly ITicketService ticketService;

        public ModerationController(IUserService userService, 
            ISpeedRunService speedRunService, 
            ITicketService ticketService)
        {
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
    }
}
