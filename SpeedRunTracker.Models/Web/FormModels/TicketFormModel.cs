using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SpeedRunTracker.Common.EntityValidataions.SupportTicketValidations;

namespace SpeedRunTracker.Models.Web.FormModels
{
    public class TicketFormModel
    {
        [Required]
        [StringLength(MaxTitleLenght, MinimumLength = MinTitleLenght, ErrorMessage = "Title must be between {2} and {1} symbols long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxContentLenght, MinimumLength = MinTitleLenght, ErrorMessage = "Content must be between {2} and {1} symbols long.")]
        public string Content { get; set; } = null!;

        public Guid IssuerId { get; set; }
    }
}
