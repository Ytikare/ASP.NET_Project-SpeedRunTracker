using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Models.Web.ApiModels;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Services
{
    public class SpeedRunService : ISpeedRunService
    {
        private readonly SpeedRunTrackerDbContext dbContext;

        public SpeedRunService(SpeedRunTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddSpeedRunAsync(SpeedRunFormModel model, string speedRunerId)
        {
            //TODO: Implement idiot proofing
            bool check = TimeSpan.TryParse(model.SpeedRunTime, out TimeSpan time);

            if (check == false)
            {
                throw new InvalidOperationException("");
            }

            SpeedRun sr = new SpeedRun()
            {
                SpeedRunerId = Guid.Parse(speedRunerId),
                CategoryId = model.CategoryId,
                GameId = model.GameId,
                SpeedRunVideoUrl = model.SpeedRunVideoUrl,
                SpeedRunTime = time,
            };

            await dbContext.SpeedRuns.AddAsync(sr);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckSpeedRunExitsAsync(string speedRunId)
        {
            return await dbContext.SpeedRuns.AnyAsync(s => s.Id.ToString().ToUpper() == speedRunId);
        }

        public async Task<IEnumerable<SpeedRunModerationViewModel>> GetOldestFiveUnverifiedSpeedRunsAsync()
        {
            ICollection<SpeedRunModerationViewModel> data = await dbContext.SpeedRuns
                .Where(s => s.IsActive == true && s.IsVerified == false)
                .OrderByDescending(s => s.SubmitionDate)
                .Take(5)
                .Select(s => new SpeedRunModerationViewModel()
                {
                    Id = s.Id.ToString(),
                    Category = s.Category.Name,
                    GameTitle = s.Game.Title,
                    Duration = s.SpeedRunTime.ToString("g"),
                    GameImageUrl = s.Game.ImgUrl,
                    SubmitionDate = s.SubmitionDate.ToString("dd/MM/yyyy"),
                    SpeedRunnerName = s.SpeedRuner.UserName
                }).ToListAsync();


            return data;
        }

        public async Task<SpeedRunDetailsViewModel> GetSpeedRunDetailsAsync(string speedRunId)
        {
            SpeedRunDetailsViewModel model = await dbContext.SpeedRuns
                .Where(s => s.Id.ToString() == speedRunId)
                .Select(s => new SpeedRunDetailsViewModel()
                {
                    Id = s.Id,
                    Category = s.Category.Name,
                    GameTitle = s.Game.Title,
                    IsActive = s.IsActive,
                    SpeedRuner = s.SpeedRuner.UserName,
                    IsVerified = s.IsVerified,
                    SpeedRunTime = s.SpeedRunTime,
                    SpeedRunVideoUrl = s.SpeedRunVideoUrl,
                    SubmitionDate = s.SubmitionDate,
                    VerificationDate = s.VerificationDate.HasValue ? s.VerificationDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                    VerifierName = s.VerifierName,
                    GameImage = s.Game.ImgUrl
                })
                .FirstAsync();

            return model;
        }
    }
}
