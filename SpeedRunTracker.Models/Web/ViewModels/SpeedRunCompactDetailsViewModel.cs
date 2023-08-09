namespace SpeedRunTracker.Models.Web.ViewModels
{
    public class SpeedRunCompactDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string GameTitle { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public string GameImageUrl { get; set; } = null!;
        public string SubmitionDate { get; set; } = null!;
        public string SpeedRunnerName { get; set; } = null!;
    }
}
