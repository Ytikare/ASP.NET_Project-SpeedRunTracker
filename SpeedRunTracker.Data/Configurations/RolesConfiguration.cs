using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedRunTracker.Data.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(GenerateData());
        }

        private IdentityRole<Guid>[] GenerateData()
        {
            ICollection<IdentityRole<Guid>> roles = new HashSet<IdentityRole<Guid>>();

            IdentityRole<Guid> role = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("B3CB43C8-0557-4F89-92EF-AAB61426C85F".ToLower()),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "993da679-48b1-4005-8f79-db5576916202"
            };
            roles.Add(role);

            role = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("BD04980A-4718-47DF-8A05-DB07D6D91458".ToLower()),
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "564200c4-f327-4867-a1dc-afa69435b948"
            };
            roles.Add(role);

            role = new IdentityRole<Guid>()
            {
                Id = Guid.Parse("3AF205A4-079E-4464-8004-CFA98FFC3BB7".ToLower()),
                Name = "Moderator",
                NormalizedName = "Moderator",
                ConcurrencyStamp = "17490783-f81e-45b5-b6f1-8dd7b9275356"
            };
            roles.Add(role);

            return roles.ToArray();
        }
    }
}
