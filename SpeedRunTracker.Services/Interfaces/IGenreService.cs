using SpeedRunTracker.Models.Web.FormModels;

namespace SpeedRunTracker.Services.Interfaces
{
    public interface IGenreService
    {
        public Task<bool> DoesGenreExistsAsync(string genreType);

        public Task AddGenreAsync(GenreFormModel model);
    }
}
