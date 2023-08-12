using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
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

        public async Task<bool> CheckIfArrayContainsInvalidCategoriesAsync(IEnumerable<string> data)
        {
            foreach (var str in data)
            {
                if (await dbContext.Categories.AnyAsync(c => c.Name.ToLower().Equals(str.Trim().ToLower())) == false)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task CreateCategoryAsync(CategoryFormModel model)
        {
            Category c = new Category()
            {
                Name = model.CategoryName
            };

            await dbContext.Categories.AddAsync(c);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesCategoryExistsByNameAsync(string categoryName) => 
            await dbContext.Categories.AnyAsync(c => c.Name.ToLower().Equals(categoryName.ToLower()));

        public async Task<IEnumerable<string>> GetAllCategoryNamesAsync() => 
            await dbContext.Categories.Select(c => c.Name).ToArrayAsync();

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

        public async Task<bool> IsCategoryIdValid(int categoryId)
        {
            return await dbContext.Categories.AnyAsync(c => c.Id == categoryId);
        }
    }
}
