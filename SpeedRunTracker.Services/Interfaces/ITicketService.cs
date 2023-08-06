using Microsoft.AspNetCore.Authentication;
using SpeedRunTracker.Models.Web.FormModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface ITicketService
    {
        public Task GenerateTicketAsync(TicketFormModel model, string userId);
    }
}
