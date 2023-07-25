using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedRunTracker.Data.Entities;

namespace SpeedRunTracker.Data.Configurations
{
    public class GameCategoriesConfiguration : IEntityTypeConfiguration<GameCategories>
    {
        public void Configure(EntityTypeBuilder<GameCategories> builder)
        {
            builder.HasKey(gc => new { gc.CategoryId, gc.GameId });
            builder.HasData(GenerateData());
        }

        private GameCategories[] GenerateData()
        {
            ICollection<GameCategories> gameCategories = new HashSet<GameCategories>();

            GameCategories gc = new()
            {
                GameId = 1,
                CategoryId = 1
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 1,
                CategoryId = 3
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 2,
                CategoryId = 1
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 2,
                CategoryId = 2
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 3,
                CategoryId = 3
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 3,
                CategoryId = 4
            };
            gameCategories.Add(gc);


            gc = new()
            {
                GameId = 4,
                CategoryId = 1
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 4,
                CategoryId = 2
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 4,
                CategoryId = 3
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 4,
                CategoryId = 4
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 5,
                CategoryId = 1
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 5,
                CategoryId = 3
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 6,
                CategoryId = 3
            };
            gameCategories.Add(gc);

            gc = new()
            {
                GameId = 6,
                CategoryId = 4
            };
            gameCategories.Add(gc);

            return gameCategories.ToArray();
        }
    }
}