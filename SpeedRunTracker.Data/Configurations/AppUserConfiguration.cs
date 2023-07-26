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

            return data.ToArray();
        }
    }
}
