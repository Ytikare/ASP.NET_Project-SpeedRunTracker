using System.ComponentModel.DataAnnotations;
using static SpeedRunTracker.Common.EntityValidataions.GenreValidations;

namespace SpeedRunTracker.Models.Web.FormModels
{
    public class GenreFormModel
    {
        [Required]
        [Display(Name = "Genre type")]
        [StringLength(MaxTypeLenght, MinimumLength = MinTypeLenght, ErrorMessage = "Type lenght must be between {2} and {1} characters long.")]
        public string GenreType { get; set; } = null!;
    }
}
