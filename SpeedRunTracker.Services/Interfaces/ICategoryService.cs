using SpeedRunTracker.Models.Web.FormModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<SpeedRunSelectCategoryFormModel>> GetCategoriesAsync(int gameId);

        public Task<bool> IsCategoryIdValid(int categoryId);

        public Task CreateCategoryAsync(CategoryFormModel model);

        public Task<bool> DoesCategoryExistsByNameAsync(string categoryName);
        
        public Task<IEnumerable<string>> GetAllCategoryNamesAsync();

        public Task<bool> CheckIfArrayContainsInvalidCategoriesAsync(IEnumerable<string> data);
    }
}
