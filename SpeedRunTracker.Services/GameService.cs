using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Services
{
    public class GameService : IGameService
    {
        private readonly SpeedRunTrackerDbContext dbContext;
        public GameService(SpeedRunTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<SpeedRunSelectGameFormModel>> GetAllGameTitlesAsync(string value)
        {
            return await dbContext
                .Games
                .Where(g => g.Title.ToLower().Contains(value.ToLower()))
                .Take(3)
                .OrderBy(g => g.Title)
                .Select(g => new SpeedRunSelectGameFormModel() 
                {
                    GameTitle = g.Title,
                    Id = g.Id,
                })
                .ToListAsync();
        }
    }
}
