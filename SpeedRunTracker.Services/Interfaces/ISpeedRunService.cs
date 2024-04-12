using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface ISpeedRunService
    {
        public Task<string> AddSpeedRunAsync(SpeedRunFormModel model, string speedRunnerId);

        public Task<IEnumerable<SpeedRunCompactDetailsViewModel>> GetOldestFiveUnverifiedSpeedRunsAsync();
        
        public Task<IEnumerable<SpeedRunCompactDetailsViewModel>> GetLatestVerifiedSpeedRunsAsync();

        public Task<bool> CheckSpeedRunExitsAsync(string speedRunId);

        public Task<SpeedRunDetailsViewModel> GetSpeedRunDetailsAsync(string speedRunId);

        public Task VerifySpeedRunAsync(string speedRunId, string verifierUsername);
        
        public Task DisqualifySpeedRunAsync(SpeedRunDisqualifyModel model, string speedRunId);

        public Task<IEnumerable<MySpeedRunViewModel>> GetMySpeedRunsAsync(string userId);
    }
}
