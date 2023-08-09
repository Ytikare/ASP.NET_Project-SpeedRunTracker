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

        public async Task<bool> IsGameIdValidAsync(int gameId)
        {
            return await dbContext.Games.AnyAsync(g => g.Id == gameId);
        }
    }
}
