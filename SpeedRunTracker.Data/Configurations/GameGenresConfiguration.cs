using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedRunTracker.Data.Entities;

namespace SpeedRunTracker.Data.Configurations
{
    public class GameGenresConfiguration : IEntityTypeConfiguration<GameGenres>
    {
        public void Configure(EntityTypeBuilder<GameGenres> builder)
        {
            builder.HasKey(gg => new { gg.GenreId, gg.GameId });

            builder.HasData(GenerateData());
        }

        private GameGenres[] GenerateData()
        {
            ICollection<GameGenres> gameGenres = new HashSet<GameGenres>();

            GameGenres gameGenre = new()
            {
                GameId = 2,
                GenreId = 7,
            };
            gameGenres.Add(gameGenre);

            gameGenre = new()
            {
                GameId = 3,
                GenreId = 5,
            };
            gameGenres.Add(gameGenre);

            gameGenre = new()
            {
                GameId = 1,
                GenreId = 4,
            };
            gameGenres.Add(gameGenre);

            gameGenre = new()
            {
                GameId = 1,
                GenreId = 6,
            };
            gameGenres.Add(gameGenre);

            gameGenre = new()
            {
                GameId = 5,
                GenreId = 7,
            };
            gameGenres.Add(gameGenre);

            gameGenre = new()
            {
                GameId = 5,
                GenreId = 2,
            };
            gameGenres.Add(gameGenre);

            gameGenre = new()
            {
                GameId = 4,
                GenreId = 2,
            };
            gameGenres.Add(gameGenre);
            
            gameGenre = new()
            {
                GameId = 6,
                GenreId = 1,
            };
            gameGenres.Add(gameGenre);



            return gameGenres.ToArray();
        }
    }
}