using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Common.Enums;
using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;
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

        public async Task<bool> CheckIfEmailExitsAsync(string email)
        {
            return await dbContext.Users.AnyAsync(u => u.Email.Equals(email));
        }

        public async Task<bool> CheckIfUserIdExitsasync(string id)
        {
            return await dbContext.Users.AnyAsync(s => s.Id.ToString().ToLower().Equals(id.ToLower()));
        }

        public async Task<bool> CheckIfUsernameExitsAsync(string username)
        {
            return await dbContext.Users.AnyAsync(u => u.UserName.Equals(username));
        }

        public async Task<IEnumerable<ModeratorFormModel>> GetMatchingUsernamesAsync(string value)
        {
            return await dbContext.Users
                .Where(u => u.UserName.Contains(value))
                .Take(3)
                .Select(u => new ModeratorFormModel()
                {
                    Id = u.Id.ToString(),
                    Username = u.UserName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ModeratorViewModel>> GetModeratorsAsync()
        {
            string roleId = await dbContext.Roles.AsNoTracking().Where(r => r.Name.Equals(ApplicationRoles.Moderator.ToString())).Select(r => r.Id.ToString()).FirstAsync();
            var data = await dbContext.UserRoles.AsNoTracking().Where(ur => ur.RoleId.ToString().Equals(roleId)).Select(ur => ur.UserId).ToListAsync();

            var users = await dbContext.Users
                .Where(u => data.Contains(u.Id))
                .Select(u => new ModeratorViewModel()
                {
                    Id = u.Id.ToString(),
                    Username = u.UserName
                }).ToListAsync();

            return users;
        }

        public async Task<bool> IsUserAModAsync(string modUserId)
        {
            AppUser u = await dbContext.Users.AsNoTracking().Where(u => u.Id.ToString().Equals(modUserId)).FirstAsync();
            
            string roleId = await dbContext.Roles.AsNoTracking().Where(r => r.Name.Equals(ApplicationRoles.Moderator.ToString())).Select(r => r.Id.ToString()).FirstAsync();

            return await dbContext.UserRoles.AnyAsync(ur => ur.RoleId.ToString().ToLower() == roleId.ToLower() && ur.UserId.ToString().ToLower() == modUserId.ToLower());
        }

        public async Task MakeModeratorAsync(string userId)
        {
            var userRoleId = await dbContext.Roles.Where(r => r.Name == ApplicationRoles.User.ToString()).Select(r => r.Id).FirstAsync();
            var modRoleId = await dbContext.Roles.Where(r => r.Name == ApplicationRoles.Moderator.ToString()).Select(r => r.Id).FirstAsync();

            var ur = await dbContext.UserRoles
                .Where(ur => ur.RoleId.ToString() == userRoleId.ToString() && ur.UserId.ToString().ToLower() == userId).FirstAsync();

            dbContext.UserRoles.Remove(ur);

            var newUserRole = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse(userId),
                RoleId = modRoleId
            };

            await dbContext.UserRoles.AddAsync(newUserRole);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveModeratorAsync(string userId)
        {
            var userRoleId = await dbContext.Roles.Where(r => r.Name == ApplicationRoles.User.ToString()).Select(r => r.Id).FirstAsync();
            var modRoleId = await dbContext.Roles.Where(r => r.Name == ApplicationRoles.Moderator.ToString()).Select(r => r.Id).FirstAsync();

            var ur = await dbContext.UserRoles
                .Where(ur => ur.RoleId.ToString() == modRoleId.ToString() && ur.UserId.ToString().ToLower() == userId).FirstAsync();

            dbContext.UserRoles.Remove(ur);

            var newUserRole = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse(userId),
                RoleId = userRoleId
            };

            await dbContext.UserRoles.AddAsync(newUserRole);
            await dbContext.SaveChangesAsync();
        }
    }
}
