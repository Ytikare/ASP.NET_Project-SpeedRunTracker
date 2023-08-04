namespace SpeedRunTracker.Models.Web.ViewModels
{
    public class SpeedRunDetailsViewModel
    {
        public Guid Id { get; set; }

        public virtual string SpeedRuner { get; set; } = null!;

        public string GameTitle { get; set; } = null!;

        public string GameImage { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string SpeedRunVideoUrl { get; set; } = null!;

        public DateTime SubmitionDate { get; set; }

        public bool IsVerified { get; set; }

        public string? VerificationDate { get; set; }

        public TimeSpan SpeedRunTime { get; set; }

        public bool IsActive { get; set; }

        public string? VerifierName { get; set; }
    }
}
