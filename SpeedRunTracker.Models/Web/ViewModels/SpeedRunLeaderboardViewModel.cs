namespace SpeedRunTracker.Models.Web.ViewModels
{
    public class SpeedRunLeaderboardViewModel
    {
        public string Id { get; set; } = null!;
        public string SpeedRunnerUsername { get; set; } = null!;
        public DateTime SubmitionDate { get; set; }
        public string RunDuraiton { get; set; } = null!;
    }
}
