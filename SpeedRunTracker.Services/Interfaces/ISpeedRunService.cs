using SpeedRunTracker.Models.Web.FormModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface ISpeedRunService
    {
        public Task AddSpeedRunAsync(SpeedRunFormModel model, string speedRunnerId);
    }
}
