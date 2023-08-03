﻿using SpeedRunTracker.Models.Web.ApiModels;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface ISpeedRunService
    {
        public Task AddSpeedRunAsync(SpeedRunFormModel model, string speedRunnerId);

        public Task<IEnumerable<SpeedRunModerationViewModel>> GetOldestFiveUnverifiedSpeedRunsAsync();

        public Task<bool> CheckSpeedRunExitsAsync(string speedRunId);

        public Task<SpeedRunDetailsViewModel> GetSpeedRunDetailsAsync(string speedRunId);
    }
}
