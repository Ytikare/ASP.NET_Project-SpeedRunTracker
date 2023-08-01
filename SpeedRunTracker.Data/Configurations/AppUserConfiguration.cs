using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedRunTracker.Data.Entities;

namespace SpeedRunTracker.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(GenerateData());
        }

        private AppUser[] GenerateData()
        {
            ICollection<AppUser> data = new HashSet<AppUser>();

            AppUser user = new AppUser()
            {
                Id = Guid.Parse("DE5697F9-1610-4C65-986D-998A20D207EC"),
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEHAsiq3wRGnN1Iz5IWJgkYPD3ENZaHWSyQwp6Aw7uv4Yy8dPpgbsxMQDJIMn1Dl9sw==",
                SecurityStamp = "MPCRSFQ7OON7DFGOA2356FQUFLAR7AMK",
                ConcurrencyStamp = "f3ab34e0-8e81-40f5-bc42-365a5cac76f1",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            data.Add(user);

            user = new AppUser()
            {
                Id = Guid.Parse("6A490127-80C3-49C1-B851-A6A24BE09EC7"),
                UserName = "Moderator",
                NormalizedUserName = "MODERATOR",
                Email = "moderator@mod.com",
                NormalizedEmail = "MODERATOR@MOD.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEMnyeOwW3ebfuZp0Ffs+zwn4N05jnXVXy7bK1mjoDydXgZexJdbe5lWsJgXflVSRNw==",
                SecurityStamp = "OBY4VDKW34POTHNHYJIASQW3MTGIOR42",
                ConcurrencyStamp = "bd00ab02-3449-45bc-88c0-4582d58a147b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            data.Add(user);

            user = new AppUser()
            {
                Id = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                UserName = "User",
                NormalizedUserName = "USER",
                Email = "user@users.com",
                NormalizedEmail = "USER@USERS.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEB3MVjgCt8z3Kiu4qTg1LsJgiQeM5nUYI6rDnSNJ5SCDMzktBmzmo8JzMq0MdcxKjA==",
                SecurityStamp = "TSNRHBY6H2J4FRYTZVNRTHASL2OAI6LB",
                ConcurrencyStamp = "bfb3560c-3135-47b4-aa22-f7903def1f7d",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            data.Add(user);

            return data.ToArray();
        }
    }
}
