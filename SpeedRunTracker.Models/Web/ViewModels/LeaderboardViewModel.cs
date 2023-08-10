namespace SpeedRunTracker.Models.Web.ViewModels
{
    public class LeaderboardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public List<SpeedRunLeaderboardViewModel> SpeedRuns { get; set; } = null!;

        public IEnumerable<SpeedRunCategoriesLeaderboardViewModel> Categories { get; set; } = null!;

        public IEnumerable<string> Genres { get; set; } = null!;
     
        //public IEnumerable<SpeedRunLeaderboardViewModel> RecentSpeedRuns { get; set; } = null!;
    }
}
