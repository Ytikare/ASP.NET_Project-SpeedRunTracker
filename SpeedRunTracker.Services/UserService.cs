using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Services
{
    public class UserService : IUserService
    {
        private SpeedRunTrackerDbContext dbContext;

        public UserService(SpeedRunTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckIfEmailExits(string email)
        {
            return await dbContext.Users.AnyAsync(u => u.Email.Equals(email));
        }

        public async Task<bool> CheckIfUsernameExits(string username)
        {
            return await dbContext.Users.AnyAsync(u => u.UserName.Equals(username));
        }
    }
}
