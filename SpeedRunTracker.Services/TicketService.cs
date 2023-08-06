using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;
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

        public async Task CompleteTicketAsync(string ticketId)
        {
            SupportTicket t = await dbContext.SupportTickets
                .Where(t => t.Id.ToString().Equals(ticketId))
                .FirstAsync();

            t.IsActive = false;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeclineTicketAsync(string ticketId)
        {
            SupportTicket t = await dbContext.SupportTickets
                .Where(t => t.Id.ToString().Equals(ticketId))
                .FirstAsync();

            t.IsActive = false;
            t.IsDeclined = false;

            await dbContext.SaveChangesAsync();
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

        public async Task<IEnumerable<TicketDashboardViewModel>> GetOldestFiveActiveTicketsAsync()
        {
            return await dbContext.SupportTickets
                .Where(t => t.IsActive == true)
                .OrderByDescending(t => t.IssueDate)
                .Take(5)
                .Select(t => new TicketDashboardViewModel 
                {
                    Title = t.Title,
                    Content = t.Content,
                    Id = t.Id.ToString(),
                    Submitter = t.Issuer.UserName,
                })
                .ToListAsync();
        }
    }
}
