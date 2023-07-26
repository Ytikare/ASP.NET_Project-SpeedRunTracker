using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SpeedRunTracker.Data.Configurations
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(GenerateData());
        }

        private static IdentityUserRole<Guid>[] GenerateData()
        {
            ICollection<IdentityUserRole<Guid>> data = new HashSet<IdentityUserRole<Guid>>();

            var temp = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse("DE5697F9-1610-4C65-986D-998A20D207EC"),
                RoleId = Guid.Parse("B3CB43C8-0557-4F89-92EF-AAB61426C85F")
            };

            data.Add(temp);

            return data.ToArray();
        }
    }
}
