using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedRunTracker.Data.Entities;

namespace SpeedRunTracker.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(GenerateData());
        }

        private Category[] GenerateData()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category = new() 
            {
                Id = 1,
                Name = "Any%",
            };
            categories.Add(category);

            category = new()
            {
                Id = 2,
                Name = "Any% Glitchless",
            };
            categories.Add(category);

            category = new()
            {
                Id = 3,
                Name = "100%",
            };
            categories.Add(category);

            category = new()
            {
                Id = 4,
                Name = "100% Glitchless ",
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
