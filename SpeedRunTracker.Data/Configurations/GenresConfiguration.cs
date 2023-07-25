using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedRunTracker.Data.Entities;

namespace SpeedRunTracker.Data.Configurations
{
    public class GenresConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(GenerateData());
        }

        private Genre[] GenerateData()
        {
            ICollection<Genre> genres = new HashSet<Genre>();

            Genre genre = new()
            {
                Id = 1,
                Type = "Souls-like"
            };
            genres.Add(genre);

            genre = new()
            {
                Id = 2,
                Type = "Adventure"
            };
            genres.Add(genre);

            genre = new()
            {
                Id = 3,
                Type = "Strategy"
            };
            genres.Add(genre);

            genre = new()
            {
                Id = 4,
                Type = "Puzzle"
            };
            genres.Add(genre);

            genre = new()
            {
                Id = 5,
                Type = "Rouge-like"
            };
            genres.Add(genre);

            genre = new()
            {
                Id = 6,
                Type = "RPG"
            };
            genres.Add(genre);

            genre = new()
            {
                Id = 7,
                Type = "Side scroller"
            };
            genres.Add(genre);

            return genres.ToArray();
        }
    }
}
