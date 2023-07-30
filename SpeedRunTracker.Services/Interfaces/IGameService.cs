using SpeedRunTracker.Models.Web.FormModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface IGameService
    {
        public Task<IEnumerable<SpeedRunSelectGameFormModel>> GetAllGameTitlesAsync(string value);
    }
}
