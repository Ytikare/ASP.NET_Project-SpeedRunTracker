using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Web.Controllers
{
    [Authorize(Roles = "Moderator, Admin")]
    public class ModerationController : Controller
    {
        private readonly IUserService userService;

        public ModerationController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
