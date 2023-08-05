using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedRunTracker.Data.Entities
{
    using static Common.EntityValidataions.SpeedRunValidations;
    public class SpeedRun
    {
        public SpeedRun()
        {
            Id = Guid.NewGuid();
            SubmitionDate = DateTime.UtcNow;
            IsVerified = false;
            IsActive = true;
        }

        [Key]
        public Guid Id { get; set; }
     
        public Guid SpeedRunerId { get; set; }

        [ForeignKey(nameof(SpeedRunerId))]
        public virtual AppUser SpeedRuner { get; set; } = null!;


        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;


        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;


        [Required]
        [MaxLength(MaxSpeedRunVideoUrlLenght)]
        [Url]
        public string SpeedRunVideoUrl { get; set; } = null!;

        [Required]
        public DateTime SubmitionDate { get; set; }

        [Required]
        public bool IsVerified { get; set; }

        public DateTime? VerificationDate { get; set; }

        [Required]
        public TimeSpan SpeedRunTime { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public string? VerifierName { get; set; }

        [MaxLength(MaxDisqualificationReasonLenght)]
        public string? DisqualificationReason { get; set; }
    }
}
