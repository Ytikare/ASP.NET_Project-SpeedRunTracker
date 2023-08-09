using SpeedRunTracker.Models.Web.ViewModels;

namespace SpeedRunTracker.Services.Models
{
    public class AllGamesSortedServiceModel
    {
        public int TotalGames { get; set; }

        public IEnumerable<GameAllViewModel> Games { get; set; } = null!;
    }
}
