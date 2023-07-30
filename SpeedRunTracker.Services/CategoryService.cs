using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Services
{

    public class CategoryService : ICategoryService
    {
        private readonly SpeedRunTrackerDbContext dbContext;
        public CategoryService(SpeedRunTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<SpeedRunSelectCategoryFormModel>> GetCategoriesAsync(int gameId)
        {
            return await dbContext
                .Categories
                .Where(c => c.Games.Any(gc => gc.GameId == gameId))
                .OrderBy(c => c.Name)
                .Select(c => new SpeedRunSelectCategoryFormModel() 
                {
                    Id = c.Id,
                    Category = c.Name
                })
                .ToListAsync();
        }
    }
}
