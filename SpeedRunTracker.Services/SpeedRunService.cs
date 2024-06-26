﻿using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
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

        public async Task<string> AddSpeedRunAsync(SpeedRunFormModel model, string speedRunerId)
        {
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

            return sr.Id.ToString();
        }

        public async Task<bool> CheckSpeedRunExitsAsync(string speedRunId)
        {
            return await dbContext.SpeedRuns.AnyAsync(s => s.Id.ToString().ToUpper() == speedRunId);
        }

        public async Task DisqualifySpeedRunAsync(SpeedRunDisqualifyModel model, string speedRunId)
        {
            SpeedRun s = await dbContext.SpeedRuns.Where(s => s.Id.ToString() == speedRunId).FirstAsync();

            s.IsVerified = false;
            s.IsActive = false;
            s.VerificationDate = null;
            s.VerifierName = null;
            s.DisqualificationReason = model.DisqulificationMessage;

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SpeedRunCompactDetailsViewModel>> GetLatestVerifiedSpeedRunsAsync()
        {
            return await dbContext.SpeedRuns
                .Where(s => s.IsVerified && s.IsActive)
                .Take(15)
                .Select(s => new SpeedRunCompactDetailsViewModel()
                {
                    Id = s.Id.ToString(),
                    Category = s.Category.Name,
                    GameTitle = s.Game.Title,
                    Duration = s.SpeedRunTime.ToString("g"),
                    GameImageUrl = s.Game.ImgUrl,
                    SubmitionDate = s.SubmitionDate.ToString("dd/MM/yyyy"),
                    SpeedRunnerName = s.SpeedRuner.UserName
                })
                .ToArrayAsync();
        }

        public async Task<IEnumerable<MySpeedRunViewModel>> GetMySpeedRunsAsync(string userId)
        {
            return await dbContext.SpeedRuns
                .Where(s => s.SpeedRuner.Id.ToString().Equals(userId))
                .Select(s => new MySpeedRunViewModel()
                {
                    Id = s.Id.ToString(),
                    Category = s.Category.Name,
                    Duration = s.SpeedRunTime.ToString("g"),
                    IsActive = s.IsActive,
                    SpeedRunnerName = s.SpeedRuner.UserName,
                    IsVerified = s.IsVerified,
                    GameImageUrl = s.Game.ImgUrl,
                    GameTitle = s.Game.Title,
                    SubmitionDate = s.SubmitionDate.ToString("dd/MM/yyyy")
                })
                .ToArrayAsync();
        }

        public async Task<IEnumerable<SpeedRunCompactDetailsViewModel>> GetOldestFiveUnverifiedSpeedRunsAsync()
        {
            ICollection<SpeedRunCompactDetailsViewModel> data = await dbContext.SpeedRuns
                .Where(s => s.IsActive == true && s.IsVerified == false)
                .OrderByDescending(s => s.SubmitionDate)
                .Take(5)
                .Select(s => new SpeedRunCompactDetailsViewModel()
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
                .Include(s => s.SpeedRuner)
                .Include(s => s.Game)
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

        public async Task VerifySpeedRunAsync(string speedRunId, string verifierUsername)
        {
            SpeedRun sp = await dbContext.SpeedRuns.FirstAsync(s => s.Id.ToString() == speedRunId);

            sp.IsVerified = true;
            sp.VerificationDate = DateTime.UtcNow;
            sp.VerifierName = verifierUsername;

            dbContext.SaveChanges();
        }
    }
}
