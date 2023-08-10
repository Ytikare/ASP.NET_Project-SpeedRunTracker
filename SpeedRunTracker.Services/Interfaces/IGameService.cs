using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Models;
using System.Reflection.Emit;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface IGameService
    {
        public Task<IEnumerable<SpeedRunSelectGameFormModel>> GetAllGameTitlesAsync(string value);

        public Task<bool> IsGameIdValidAsync(int gameId);

        public Task<AllGamesSortedServiceModel> AllGamesAsync(BrowseGamesQueryModel queryModel);

        public Task<LeaderboardViewModel> GetLeaderboardDataAsync(int gameId, int categoryId);
        
        public Task<bool> DoesGameExistsAsync(int gameId);
        
        public Task<bool> DoesGameContaionsCategoryAsync(int gameId, int categoryId);

        public Task AddGameAsync(GameFormModel model);

    }
}
