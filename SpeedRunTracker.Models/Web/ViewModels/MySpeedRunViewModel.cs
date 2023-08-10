namespace SpeedRunTracker.Models.Web.ViewModels
{
    public class MySpeedRunViewModel : SpeedRunCompactDetailsViewModel
    {
        public bool IsVerified { get; set; }

        public bool IsActive { get; set; }
    }
}
