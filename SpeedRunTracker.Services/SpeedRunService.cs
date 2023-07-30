using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Models.Web.FormModels;
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
    }
}
