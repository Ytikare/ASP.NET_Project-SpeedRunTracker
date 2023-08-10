using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Services
{
    public class GenreService : IGenreService
    {

        private readonly SpeedRunTrackerDbContext dbContext;
        public GenreService(SpeedRunTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddGenreAsync(GenreFormModel model)
        {
            Genre g = new Genre()
            {
                Type = model.GenreType
            };

            await dbContext.Genres.AddAsync(g);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesGenreExistsAsync(string genreType) =>
            await dbContext.Genres.AnyAsync(g => g.Type.ToLower().Equals(genreType.ToLower()));
    }
}
