using Microsoft.AspNetCore.Identity;

namespace SpeedRunTracker.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            this.Id = Guid.NewGuid();
            this.SpeedRuns = new HashSet<SpeedRun>(); 
        }

        public virtual ICollection<SpeedRun> SpeedRuns { get; set; }
    }
}
