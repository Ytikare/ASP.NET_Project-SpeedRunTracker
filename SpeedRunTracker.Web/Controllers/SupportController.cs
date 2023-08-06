using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;
using SpeedRunTracker.Web.Infrastructure.Extensions;

namespace SpeedRunTracker.Web.Controllers
{
    [AllowAnonymous]
    public class SupportController : Controller
    {
        private readonly ITicketService ticketService;

        public SupportController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Ticket()
        {
            TicketFormModel model = new TicketFormModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Ticket(TicketFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            try
            {
                await ticketService.GenerateTicketAsync(model, User.GetId()!);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unexpected error occurred. Please try again later.");
                return View(model);

            }
        }

        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> Complete(string ticketId)
        {
            await ticketService.CompleteTicketAsync(ticketId);

            return RedirectToAction("Dashboard", "Moderation");
        }

        [HttpGet]
        [Authorize(Roles = "Moderator, Admin")]
        public async Task<IActionResult> Decline(string ticketId)
        {
            await ticketService.DeclineTicketAsync(ticketId);

            return RedirectToAction("Dashboard", "Moderation");
        }
    }
}
