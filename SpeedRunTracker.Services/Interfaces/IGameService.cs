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
    }
}
