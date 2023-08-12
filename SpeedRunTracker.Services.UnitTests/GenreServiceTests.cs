using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Data;
using SpeedRunTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SpeedRunTracker.Models.Web.FormModels;

namespace SpeedRunTracker.Services.UnitTests
{
    [TestFixture]
    public class GenreServiceTests
    {
        private DbContextOptions<SpeedRunTrackerDbContext> options;
        private SpeedRunTrackerDbContext dbContext;

        private IGenreService genreService;

        [SetUp]
        public void SetUp()
        {
            this.options = new DbContextOptionsBuilder<SpeedRunTrackerDbContext>()
                .UseInMemoryDatabase(databaseName: "SpeedRunTracker_In_Memory")
                .Options;

            this.dbContext = new SpeedRunTrackerDbContext(this.options);

            List<Genre> data = new()
            {
                new Genre() { Type = "Third-Person-Shooter"}
            };

            dbContext.Database.EnsureCreated();

            dbContext.Genres.AddRange(data);
            dbContext.SaveChanges();

            genreService = new GenreService(dbContext);
        }

        [Test]
        public async Task Test_AddGenre()
        {
            var mockedGenreFormModel = new Mock<GenreFormModel>();
            mockedGenreFormModel.Object.GenreType = "First-Person-Shooter";

            await genreService.AddGenreAsync(mockedGenreFormModel.Object);

            Assert.That(dbContext.Genres.Any(g => g.Type == "First-Person-Shooter"), Is.True);
        }


        [Test]
        public async Task Test_DoesCategoryExistsByNameAsync()
        {
            string validGenreType = "Third-Person-Shooter";
            string invalidGnreType = "Platformer";

            bool validCheck = await genreService.DoesGenreExistsAsync(validGenreType);
            bool invalidCheck = await genreService.DoesGenreExistsAsync(invalidGnreType);

            Assert.That(validCheck, Is.True);
            Assert.That(invalidCheck, Is.False);
        }

        [Test]
        public async Task Test_CheckIfArrayContainsInvalidGenres()
        {
            IEnumerable<string> validTypes = new string[2]
            {
                "Adventure",
                "Puzzle"
            };

            IEnumerable<string> invalidTypes = new string[1]
            {
                "Platformer"
            };

            Assert.That(await genreService.CheckIfArrayContainsInvalidGenresAsync(validTypes), Is.False);
            Assert.That(await genreService.CheckIfArrayContainsInvalidGenresAsync(invalidTypes), Is.True);
        }

        [Test]
        public async Task Test_GetAllGenreTypes()
        {
            int entitesCountByContext = dbContext.Genres.Count();
            int entitesCountByService = 0;

            var data = await genreService.GetAllGenreTypesAsync();

            foreach (var item in data)
            {
                entitesCountByService++;
            }

            Assert.That(entitesCountByService, Is.EqualTo(entitesCountByContext));
            Assert.That(data.Contains("Third-Person-Shooter"), Is.True);
        }
    }
}
