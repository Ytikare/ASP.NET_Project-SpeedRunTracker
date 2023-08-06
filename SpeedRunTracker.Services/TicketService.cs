using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Services
{
    public class TicketService : ITicketService
    {
        private readonly SpeedRunTrackerDbContext dbContext;
        public TicketService(SpeedRunTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task GenerateTicketAsync(TicketFormModel model,string userId)
        {
            SupportTicket supportTicket = new SupportTicket()
            {
                IssuerId = Guid.Parse(userId),
                Title = model.Title,
                Content = model.Content,
                IsActive = true,
                IsDeclined = false,
                IssueDate = DateTime.UtcNow,
            };

            await dbContext.SupportTickets.AddAsync(supportTicket);
            await dbContext.SaveChangesAsync();
        }
    }
}
