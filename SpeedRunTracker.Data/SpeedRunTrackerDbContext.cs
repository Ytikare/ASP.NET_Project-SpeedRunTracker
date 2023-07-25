using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpeedRunTracker.Data
{
    public class SpeedRunTrackerDbContext : IdentityDbContext
    {
        public SpeedRunTrackerDbContext(DbContextOptions<SpeedRunTrackerDbContext> options)
            : base(options)
        {
        }
    }
}