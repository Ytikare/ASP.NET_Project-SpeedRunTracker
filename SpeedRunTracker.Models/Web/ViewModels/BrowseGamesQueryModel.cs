using System.ComponentModel.DataAnnotations;
using SpeedRunTracker.Common.Enums;
using static SpeedRunTracker.Common.GeneralApplicationConstants;
namespace SpeedRunTracker.Models.Web.ViewModels
{
    public class BrowseGamesQueryModel
    {

        public BrowseGamesQueryModel()
        {
            CurrentPage = DefaultPage;
            GamesPerPage = EntitiesPerPage;
        }

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort games by")]
        public GameSorting GameSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show games on page")]
        public int GamesPerPage { get; set; }

        public int TotalGames { get; set; }

        public IEnumerable<GameAllViewModel> Games { get; set; } = null!;
    }
}
