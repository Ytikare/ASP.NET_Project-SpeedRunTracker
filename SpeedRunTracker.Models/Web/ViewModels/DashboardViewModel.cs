namespace SpeedRunTracker.Models.Web.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<SpeedRunDashboardDetailsViewModel> SpeedRuns { get; set; } = null!;

        public IEnumerable<TicketDashboardViewModel> SupportTickets { get; set; } = null!;
    }
}
