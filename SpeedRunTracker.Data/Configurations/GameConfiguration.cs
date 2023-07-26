using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedRunTracker.Data.Entities;

namespace SpeedRunTracker.Data.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(GenerateData());
        }

        private Game[] GenerateData()
        {
            ICollection<Game> games = new HashSet<Game>();

            Game game = new Game()
            {
                Id = 1,
                Title = "Undertale",
                ImgUrl = "https://cdn.akamai.steamstatic.com/steam/apps/391540/header.jpg",
            };
            games.Add(game);

            game = new Game
            {
                Id = 2,
                Title = "Sonic the Headghog",
                ImgUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/71113/header.jpg",
            };
            games.Add(game);

            game = new Game
            {
                Id = 3,
                Title = "The binding of Isaac: Repentance",
                ImgUrl = "https://images.gog-statics.com/60741efd71f8d67d9ff221671c790782a82ac0bb5a73a7dc5d3f45801b3074da.jpg",
            };
            games.Add(game);

            game = new Game
            {
                Id = 4,
                Title = "Grant Theft Auto: San Andreas",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/c/c4/GTASABOX.jpg",
            };
            games.Add(game);

            game = new Game
            {
                Id = 5,
                Title = "Blasphemous",
                ImgUrl = "https://cdn.akamai.steamstatic.com/steam/apps/774361/header.jpg",
            };
            games.Add(game);

            game = new Game
            {
                Id = 6,
                Title = "Titanfall 2",
                ImgUrl = "https://cdn.akamai.steamstatic.com/steam/apps/1237970/header.jpg"
            };
            games.Add(game);

            return games.ToArray();
        }
    }
}
