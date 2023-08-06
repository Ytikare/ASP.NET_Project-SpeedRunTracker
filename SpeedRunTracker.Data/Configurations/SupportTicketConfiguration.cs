using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedRunTracker.Data.Entities;

namespace SpeedRunTracker.Data.Configurations
{
    public class SupportTicketConfiguration : IEntityTypeConfiguration<SupportTicket>
    {
        public void Configure(EntityTypeBuilder<SupportTicket> builder)
        {
            builder.HasData(GenerateData());
        }

        private SupportTicket[] GenerateData()
        {
            var data = new HashSet<SupportTicket>();

            SupportTicket sp = new SupportTicket()
            {
                Id = Guid.Parse("f808b07afb80414eb24ace392cb91729"),
                Title = "Requesting speedrun verification",
                Content = "Most of my speedruns have not been verified. Since all of them are valid, would you verify them, please?",
                IssuerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                IssueDate = DateTime.Parse("2023-08-05T07:50:40Z").AddDays(-22),
                IsActive = true,
                IsDeclined = false,

            };
            data.Add(sp);

            sp = new SupportTicket()
            {
                Id = Guid.Parse("921296be33ca4853887c7c5cea0e0f2b"),
                Title = "Requseting new game to be added - Only Up!",
                Content = "I request the game Only Up! to be added. since it has a large speedrunning commynity around it.",
                IssuerId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                IssueDate = DateTime.Parse("2023-08-05T07:50:40Z").AddDays(-33),
                IsActive = true,
                IsDeclined = false,

            };
            data.Add(sp);

            return data.ToArray();
        }
    }
}
