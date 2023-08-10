using SpeedRunTracker.Models.Web.FormModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface IGenreService
    {
        public Task<bool> DoesGenreExistsAsync(string genreType);

        public Task AddGenreAsync(GenreFormModel model);

        public Task<IEnumerable<string>> GetAllGenreTypesAsync();
        
        public Task<bool> CheckIfArrayContainsInvalidGenresAsync(IEnumerable<string> data);
    }
}
