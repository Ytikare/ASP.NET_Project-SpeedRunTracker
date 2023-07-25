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
                ImgUrl = "https://www.speedrun.com/gameasset/4d73n317/cover?v=694f4a9",
            };
            games.Add(game);

            game = new Game
            {
                Id = 2,
                Title = "Sonic the Headghog",
                ImgUrl = "https://www.speedrun.com/gameasset/4pdv0o1w/cover?v=938fb1b",
            };
            games.Add(game);

            game = new Game
            {
                Id = 3,
                Title = "The binding of Isaac: Repentance",
                ImgUrl = "https://www.speedrun.com/gameasset/3dxkj5p1/cover?v=dce92be",
            };
            games.Add(game);

            game = new Game
            {
                Id = 4,
                Title = "Grant Theft Auto: San Andreas",
                ImgUrl = "https://www.speedrun.com/gameasset/yo1yv1q5/cover?v=2c7ae3d",
            };
            games.Add(game);

            game = new Game
            {
                Id = 5,
                Title = "Blasphemous",
                ImgUrl = "https://www.speedrun.com/gameasset/lde39mx6/cover?v=680736c",
            };
            games.Add(game);

            game = new Game
            {
                Id = 6,
                Title = "Titanfall 2",
                ImgUrl = "https://www.speedrun.com/gameasset/o6gen512/cover?v=c3c7ed4"
            };
            games.Add(game);

            return games.ToArray();
        }
    }
}
