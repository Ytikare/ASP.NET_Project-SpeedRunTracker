using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface ITicketService
    {
        public Task GenerateTicketAsync(TicketFormModel model, string userId);

        public Task<IEnumerable<TicketDashboardViewModel>> GetOldestFiveActiveTicketsAsync();
    }
}
