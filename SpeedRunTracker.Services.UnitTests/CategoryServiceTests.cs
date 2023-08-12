using Microsoft.EntityFrameworkCore;
using Moq;
using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Services.Interfaces;

namespace SpeedRunTracker.Services.UnitTests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private DbContextOptions<SpeedRunTrackerDbContext> options;
        private SpeedRunTrackerDbContext dbContext;

        private ICategoryService categoryService;

        //Aperantly the dbContext uses its configurations in unit testing to. The more you know
        [SetUp]
        public void SetUp()
        {
            this.options = new DbContextOptionsBuilder<SpeedRunTrackerDbContext>()
                .UseInMemoryDatabase(databaseName: "SpeedRunTracker_In_Memory")
                .Options;

            this.dbContext = new SpeedRunTrackerDbContext(this.options);

            List<Category> data = new()
            {
                new Category() { Name = "Tutorial"}
            };

            dbContext.Database.EnsureCreated();

            dbContext.Categories.AddRange(data);
            dbContext.SaveChanges();

            categoryService = new CategoryService(dbContext);
        }

        [Test]
        public async Task Test_CreateCategory()
        {
            var mockedCategoryFormModel = new Mock<CategoryFormModel>();
            mockedCategoryFormModel.Object.CategoryName = "Tutorial Glitchless";

            await categoryService.CreateCategoryAsync(mockedCategoryFormModel.Object);

            Assert.That(dbContext.Categories.Any(c => c.Name == "Tutorial Glitchless"), Is.True);
        }

        [Test]
        public async Task Test_IsCategoryIdValid()
        {
            int validCategoryId = 1;
            int invalidCategoryId = 100;

            bool validCheck = await categoryService.IsCategoryIdValid(validCategoryId);
            bool invalidCheck = await categoryService.IsCategoryIdValid(invalidCategoryId);

            Assert.That(validCheck, Is.True);
            Assert.That(invalidCheck, Is.False);
        }

        [Test]
        public async Task Test_GetAllCategoryNames()
        {
            IEnumerable<string> catNames = await categoryService.GetAllCategoryNamesAsync();

            int count = 0;

            foreach (var item in catNames)
            {
                count++;
            }

            Assert.That(count, Is.EqualTo(dbContext.Categories.Count()));
            
            Assert.Multiple(() =>
            {
                Assert.That(catNames.Contains("Tutorial"), Is.True);
                Assert.That(catNames.Contains("Tutorial Glitchless1"), Is.False);
            });
        }

        [Test]
        public async Task Test_DoesCategoryExistsByNameAsync()
        {
            string validCategoryName = "Tutorial";
            string invalidCategoryName = "Tutorial Glitchless1";

            bool validCheck = await categoryService.DoesCategoryExistsByNameAsync(validCategoryName);
            bool invalidCheck = await categoryService.DoesCategoryExistsByNameAsync(invalidCategoryName);

            Assert.That(validCheck, Is.True);
            Assert.That(invalidCheck, Is.False);
        }

        [Test]
        public async Task Test_GetCategoriesAsync()
        {
            int validGameId = await dbContext.Games.Where(x => x.Id == 1).Select(x => x.Id).FirstAsync();
            int invalidGameId = 1000000;

            IEnumerable<SpeedRunSelectCategoryFormModel> validData = await categoryService.GetCategoriesAsync(validGameId);

            IEnumerable<SpeedRunSelectCategoryFormModel> invalidData = await categoryService.GetCategoriesAsync(invalidGameId);

            int validCategoriesCount = 0;
            int invalidCategoriesCount = 0;

            foreach (var model in validData)
                validCategoriesCount++;

            foreach (var item in invalidData)
                invalidCategoriesCount++;

            Assert.That(validCategoriesCount, Is.EqualTo(dbContext.GameCategories.Where(gc => gc.GameId == validGameId).Count()));
            Assert.That(invalidCategoriesCount, Is.EqualTo(dbContext.GameCategories.Where(gc => gc.GameId == invalidGameId).Count()));
        }

        [Test]
        public async Task Test_CheckIfArrayContainsInvalidCategories()
        {
            IEnumerable<string> validNames = new string[2] 
            {
                "Any%",
                "100%"
            };

            IEnumerable<string> invalidNames = new string[1]
            {
                "Tutorial Glitchless"
            };

            Assert.That(await categoryService.CheckIfArrayContainsInvalidCategoriesAsync(validNames), Is.False);
            Assert.That(await categoryService.CheckIfArrayContainsInvalidCategoriesAsync(invalidNames), Is.True);
        }

    }
}
