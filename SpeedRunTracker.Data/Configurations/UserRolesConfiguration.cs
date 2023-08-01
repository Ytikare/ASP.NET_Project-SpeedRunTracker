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

            temp = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse("6A490127-80C3-49C1-B851-A6A24BE09EC7"),
                RoleId = Guid.Parse("3AF205A4-079E-4464-8004-CFA98FFC3BB7")
            };

            data.Add(temp);

            temp = new IdentityUserRole<Guid>()
            {
                UserId = Guid.Parse("D5001448-AC7A-4666-824D-F6A48228B3B0"),
                RoleId = Guid.Parse("BD04980A-4718-47DF-8A05-DB07D6D91458")
            };

            data.Add(temp);

            return data.ToArray();
        }
    }
}
