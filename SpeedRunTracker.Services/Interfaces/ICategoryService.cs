using SpeedRunTracker.Models.Web.FormModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<SpeedRunSelectCategoryFormModel>> GetCategoriesAsync(int gameId);

        public Task<bool> IsCategoryIdValid(int categoryId);

        public Task CreateCategoryAsync(CategoryFormModel model);

        public Task<bool> DoesCategoryExistsAsync(string categoryName);
    }
}
