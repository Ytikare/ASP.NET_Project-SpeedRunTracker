using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Models;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface IGameService
    {
        public Task<IEnumerable<SpeedRunSelectGameFormModel>> GetAllGameTitlesAsync(string value);

        public Task<bool> IsGameIdValidAsync(int gameId);

        public Task<AllGamesSortedServiceModel> AllGamesAsync(BrowseGamesQueryModel queryModel);

        public Task<LeaderboardViewModel> GetLeaderboardDataAsync(int gameId, int categoryId);
        
        public Task<bool> DoesGameExistsAsync(int gameId);
        
        public Task<bool> DoesCategoryExistsAsync(int categoryId);
        
        public Task<bool> DoesGameContaionsCategoryAsync(int gameId, int categoryId);

    }
}
