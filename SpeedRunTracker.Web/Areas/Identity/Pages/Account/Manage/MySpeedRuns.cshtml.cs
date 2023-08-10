using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Interfaces;
using SpeedRunTracker.Web.Infrastructure.Extensions;

namespace SpeedRunTracker.Web.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class MySpeedRunsModel : PageModel
    {
        private readonly ISpeedRunService speedRunService;

        public IEnumerable<MySpeedRunViewModel> MySpeedRuns { get; set; } = null!;

        public MySpeedRunsModel(ISpeedRunService speedRunService)
        {
            this.speedRunService = speedRunService;
        }

        public async Task<IActionResult> OnGet()
        {
            MySpeedRuns = await speedRunService.GetMySpeedRunsAsync(User.GetId()!);
            
            return Page();
        }
    }
}
