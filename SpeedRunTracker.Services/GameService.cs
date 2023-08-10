using Microsoft.EntityFrameworkCore;
using SpeedRunTracker.Common.Enums;
using SpeedRunTracker.Data;
using SpeedRunTracker.Data.Entities;
using SpeedRunTracker.Models.Web.FormModels;
using SpeedRunTracker.Models.Web.ViewModels;
using SpeedRunTracker.Services.Interfaces;
using SpeedRunTracker.Services.Models;

namespace SpeedRunTracker.Services
{
    public class GameService : IGameService
    {
        private readonly SpeedRunTrackerDbContext dbContext;
        public GameService(SpeedRunTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllGamesSortedServiceModel> AllGamesAsync(BrowseGamesQueryModel queryModel)
        {
            IQueryable<Game> gameQuery = dbContext.Games.AsQueryable();

            if (!string.IsNullOrEmpty(queryModel.SearchString))
            {
                gameQuery = gameQuery.Where(g => g.Title.ToLower().Contains(queryModel.SearchString.ToLower()));
            }

            gameQuery = queryModel.GameSorting switch
            {
                GameSorting.Title => gameQuery.OrderBy(g => g.Title),
                GameSorting.TitleReverse => gameQuery.OrderByDescending(g => g.Title),
                GameSorting.SpeedRunCount => gameQuery.OrderBy(g => g.SpeedRuns.Count),
                GameSorting.SpeedRunCountReverse => gameQuery.OrderByDescending(g => g.SpeedRuns.Count),
                _ => gameQuery.OrderBy(g => g.Id),
            };

            IEnumerable<GameAllViewModel> data = await gameQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.GamesPerPage)
                .Take(queryModel.GamesPerPage)
                .Select(g => new GameAllViewModel
                {
                    Id = g.Id,
                    FirstCategoryId = g.Categories.OrderBy(gc => gc.CategoryId).Select(gc => gc.CategoryId).First(),
                    ImageUrl = g.ImgUrl,
                    Title = g.Title,
                    SpeedRuns = g.SpeedRuns.Count
                })
                .ToListAsync();

            int gameCount = gameQuery.Count();

            return new AllGamesSortedServiceModel()
            {
                Games = data,
                TotalGames = gameCount
            };
        }

        public async Task<bool> DoesCategoryExistsAsync(int categoryId)
        {
            return await dbContext.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<bool> DoesGameContaionsCategoryAsync(int gameId, int categoryId)
        {
            return await dbContext.GameCategories.AnyAsync(gc => gc.CategoryId == categoryId && gc.GameId == gameId);
        }

        public async Task<bool> DoesGameExistsAsync(int gameId)
        {
            return await dbContext.Games.AnyAsync(g => g.Id == gameId);
        }

        public async Task<IEnumerable<SpeedRunSelectGameFormModel>> GetAllGameTitlesAsync(string value)
        {
            return await dbContext
                .Games
                .Where(g => g.Title.ToLower().Contains(value.ToLower()))
                .Take(3)
                .OrderBy(g => g.Title)
                .Select(g => new SpeedRunSelectGameFormModel() 
                {
                    GameTitle = g.Title,
                    Id = g.Id,
                })
                .ToListAsync();
        }

        public async Task<LeaderboardViewModel> GetLeaderboardDataAsync(int gameId, int categoryId)
        {
            LeaderboardViewModel model = await dbContext.Games
                .Where(g => g.Id == gameId)
                .Select(g => new LeaderboardViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImgUrl,
                    CategoryName = g.Categories.Where(gc => gc.CategoryId == categoryId).First().Category.Name,
                    Genres = g.Genres.Select(gg => gg.Genre.Type).ToList(),
                    Categories = g.Categories
                                .Select(gc => new SpeedRunCategoriesLeaderboardViewModel()
                                {
                                    Id = gc.CategoryId,
                                    CategoryName = gc.Category.Name
                                }).ToArray(),
                    SpeedRuns = g.SpeedRuns
                                .Where(s => s.IsVerified)
                                .Where(s => s.GameId == gameId && s.CategoryId == categoryId)
                                .OrderBy(s => s.SpeedRunTime)
                                .Take(50)
                                .Select(s => new SpeedRunLeaderboardViewModel()
                                {
                                    Id = s.Id.ToString(),
                                    RunDuraiton = s.SpeedRunTime.ToString("g"),
                                    SpeedRunnerUsername = s.SpeedRuner.UserName,
                                    SubmitionDate = s.SubmitionDate
                                })
                                .ToList(),
                    //RecentSpeedRuns = g.SpeedRuns.OrderByDescending(s => s.VerificationDate)
                    //            .Take(10)
                    //            .Select(s => new SpeedRunLeaderboardViewModel()
                    //            {
                    //                Id = s.Id.ToString(),
                    //                RunDuraiton = s.SpeedRunTime.ToString("g"),
                    //                SpeedRunnerUsername = s.SpeedRuner.UserName,
                    //                SubbmitionDate = s.SubmitionDate.ToString("dd/MM/yyyy")
                    //            })
                    //            .ToArray(),
                })
                .FirstAsync();

            return model;
        }

        public async Task<bool> IsGameIdValidAsync(int gameId)
        {
            return await dbContext.Games.AnyAsync(g => g.Id == gameId);
        }
    }
}
