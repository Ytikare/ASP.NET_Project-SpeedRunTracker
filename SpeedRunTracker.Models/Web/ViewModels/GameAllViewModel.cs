namespace SpeedRunTracker.Models.Web.ViewModels
{
    public class GameAllViewModel
    {
        public int Id { get; set; }
        public int FirstCategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        
        public int SpeedRuns { get; set; }
    }
}
