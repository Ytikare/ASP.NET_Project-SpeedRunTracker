using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Data;
using SpeedRunTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace SpeedRunTracker.Services.UnitTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private DbContextOptions<SpeedRunTrackerDbContext> options;
        private SpeedRunTrackerDbContext dbContext;

        private IUserService userService;

        [SetUp]
        public void SetUp()
        {
            this.options = new DbContextOptionsBuilder<SpeedRunTrackerDbContext>()
                .UseInMemoryDatabase(databaseName: "SpeedRunTracker_In_Memory")
                .Options;

            this.dbContext = new SpeedRunTrackerDbContext(this.options);

            dbContext.Database.EnsureCreated();

            //ICollection<AppUser> data = new HashSet<AppUser>();

            //AppUser user = new AppUser()
            //{
            //    Id = Guid.Parse("5750ee58-2e7e-44d1-a67d-09e0627cb82f"),
            //    UserName = "Ivan12",
            //    NormalizedUserName = "IVAN12",
            //    Email = "ivan@abv.bg",
            //    NormalizedEmail = "IVAN@ABV.BG",
            //    EmailConfirmed = false,
            //    PasswordHash = "AQAAAAEAACcQAAAAEHAsiq3wRGnN1Iz5IWJgkYPD3ENZaHWSyQwp6Aw7uv4Yy8dPpgbsxMQDJIMn1Dl9sw==",
            //    SecurityStamp = "AZCRSFQ7OON7DFGOA2356FQUFLAR7AMK",
            //    ConcurrencyStamp = "dc94814f-39d9-4014-bd94-da158f07d3b7",
            //    PhoneNumber = null,
            //    PhoneNumberConfirmed = false,
            //    TwoFactorEnabled = false,
            //    LockoutEnd = null,
            //    LockoutEnabled = true,
            //    AccessFailedCount = 0
            //};

            //data.Add(user);

            //user = new AppUser()
            //{
            //    Id = Guid.Parse("07ecec48-a216-4c2c-9c8e-78b36d751415"),
            //    UserName = "Pesho",
            //    NormalizedUserName = "PESHO",
            //    Email = "pesho@gmail.com",
            //    NormalizedEmail = "PESHO@GMAIL.COM",
            //    EmailConfirmed = false,
            //    PasswordHash = "AQAAAAEAACcQAAAAEB3MVjgCt8z3Kiu4qTg1LsJgiQeM5nUYI6rDnSNJ5SCDMzktBmzmo8JzMq0MdcxKjA==",
            //    SecurityStamp = "TSNRHBY6H2J6SRYTZVNRTHASL2OAI6LB",
            //    ConcurrencyStamp = "f14fc2f6-640a-4a21-b8e6-61d1c9c7bbc8",
            //    PhoneNumber = null,
            //    PhoneNumberConfirmed = false,
            //    TwoFactorEnabled = false,
            //    LockoutEnd = null,
            //    LockoutEnabled = true,
            //    AccessFailedCount = 0
            //};
            //data.Add(user);

            //dbContext.Users.AddRange(data);
            //dbContext.SaveChanges();

            userService = new UserService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }


        [Test]
        public async Task Test_CheckIfEmailExits()
        {
            string existingEmail = "admin@admin.com";
            string nonExistingEmail = "mitko@gmail.com";

            bool trueCheck = await userService.CheckIfEmailExitsAsync(existingEmail);
            bool falseCheck = await userService.CheckIfEmailExitsAsync(nonExistingEmail);

            Assert.That(trueCheck, Is.True);
            Assert.That(falseCheck, Is.False);
        }

        [Test]
        public async Task Test_CheckIfUserIdExits()
        {
            string validId = "DE5697F9-1610-4C65-986D-998A20D207EC";
            string invalidId = "aa1d524d-fb65-4c30-91c4-b492f90b58db";

            bool trueCheck = await userService.CheckIfUserIdExitsAsync(validId);
            bool falseCheck = await userService.CheckIfUserIdExitsAsync(invalidId);

            Assert.That(trueCheck, Is.True);
            Assert.That(falseCheck, Is.False);
        }

        [Test]
        public async Task Test_CheckIfUserIdExit()
        {
            string existingUsername = "Admin";
            string nonExistingUsername = "Mitko";

            bool trueCheck = await userService.CheckIfUsernameExitsAsync(existingUsername);
            bool falseCheck = await userService.CheckIfUsernameExitsAsync(nonExistingUsername);

            Assert.That(trueCheck, Is.True);
            Assert.That(falseCheck, Is.False);
        }

        [Test]
        public async Task Test_GetMatchingUsernames()
        {
            string validNamePart = "e";
            string invalidNamePart = "sdifhn";

            var validData = await userService.GetMatchingUsernamesAsync(validNamePart);
            var invalidData = await userService.GetMatchingUsernamesAsync(invalidNamePart);

            bool wordsCheck = true;

            foreach (var item in validData)
            {
                if (item.Username!.Contains(validNamePart) == false)
                {
                    wordsCheck = false;
                }
            }

            Assert.That(validData.Count(), Is.EqualTo(2));
            Assert.That(invalidData.Count(), Is.EqualTo(0));
            Assert.That(wordsCheck, Is.True);
        }


        [Test]
        public async Task Test_GetModeratorsAsync()
        {
            string validModUserName = "Moderator";
            string userUsername = "User";
            string adminUserName = "Admin";

            var data = await userService.GetModeratorsAsync();

            Assert.That(data.Count(), Is.EqualTo(1));
            Assert.That(data.Any(u => u.Username == validModUserName), Is.True);
            Assert.That(data.Any(u => u.Username == userUsername), Is.False);
            Assert.That(data.Any(u => u.Username == adminUserName), Is.False);
        }

        [Test]
        public async Task Test_IsUserAModAsync()
        {
            string validModId = "6A490127-80C3-49C1-B851-A6A24BE09EC7";
            string invalidModId = "D5001448-AC7A-4666-824D-F6A48228B3B0";

            Assert.That(await userService.IsUserAModAsync(validModId), Is.True);
            Assert.That(await userService.IsUserAModAsync(invalidModId), Is.False);
        }

        [Test]
        public async Task Test_MakeModerator()
        {
            string modRoleId = "3AF205A4-079E-4464-8004-CFA98FFC3BB7";
            string nonModUserId = "D5001448-AC7A-4666-824D-F6A48228B3B0";

            await userService.MakeModeratorAsync(nonModUserId);

            Assert.That(await dbContext.UserRoles.Where(ur => ur.RoleId.ToString().ToLower() == modRoleId.ToLower()).CountAsync(), Is.EqualTo(2));
            Assert.That(await dbContext.UserRoles.AnyAsync(ur => ur.RoleId.ToString().ToLower() == modRoleId.ToLower() && ur.UserId.ToString().ToLower() == nonModUserId.ToLower()), Is.True);
        }

        [Test]
        public async Task Test_RemoveModerator()
        {
            string modRoleId = "3AF205A4-079E-4464-8004-CFA98FFC3BB7";

            AppUser user = new AppUser()
            {
                Id = Guid.Parse("5750ee58-2e7e-44d1-a67d-09e0627cb82f"),
                UserName = "Ivan12",
                NormalizedUserName = "IVAN12",
                Email = "ivan@abv.bg",
                NormalizedEmail = "IVAN@ABV.BG",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEHAsiq3wRGnN1Iz5IWJgkYPD3ENZaHWSyQwp6Aw7uv4Yy8dPpgbsxMQDJIMn1Dl9sw==",
                SecurityStamp = "AZCRSFQ7OON7DFGOA2356FQUFLAR7AMK",
                ConcurrencyStamp = "dc94814f-39d9-4014-bd94-da158f07d3b7",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            await dbContext.Users.AddAsync(user);

            IdentityUserRole<Guid> ur = new()
            {
                RoleId = Guid.Parse(modRoleId),
                UserId = user.Id,
            };

            await dbContext.UserRoles.AddAsync(ur);

            await dbContext.SaveChangesAsync();

            await userService.RemoveModeratorAsync(user.Id.ToString());

            Assert.That(await dbContext.UserRoles.Where(ur => ur.RoleId.ToString().ToLower() == modRoleId.ToLower()).CountAsync(), Is.EqualTo(1));
            Assert.That(await dbContext.UserRoles.AnyAsync(ur => ur.RoleId.ToString().ToLower() == modRoleId.ToLower() && ur.UserId.ToString().ToLower() == user.Id.ToString().ToLower()), Is.False);
        }
    }
}
