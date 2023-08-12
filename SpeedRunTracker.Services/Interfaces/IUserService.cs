using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CheckIfUsernameExitsAsync(string username);

        public Task<bool> CheckIfUserIdExitsasync(string id);

        public Task<bool> CheckIfEmailExitsAsync(string email);

        public Task MakeModeratorAsync(string userId);

        public Task RemoveModeratorAsync(string userId);

        public Task<IEnumerable<ModeratorViewModel>> GetModeratorsAsync();
        
        public Task<bool> IsUserAModAsync(string modUserId);
        public Task<IEnumerable<ModeratorFormModel>> GetMatchingUsernamesAsync(string value);
    }
}
