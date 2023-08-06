using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SpeedRunTracker.Common.EntityValidataions.SupportTicketValidations;

namespace SpeedRunTracker.Data.Entities
{
    public class SupportTicket
    {
        public SupportTicket()
        {
            Id = Guid.NewGuid();
            IssueDate = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(MaxTitleLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MaxContentLenght)]
        public string Content { get; set; } = null!;

        public Guid IssuerId { get; set; }

        [ForeignKey(nameof(IssuerId))]
        public AppUser Issuer { get; set; } = null!;

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeclined { get; set; }

    }
}
