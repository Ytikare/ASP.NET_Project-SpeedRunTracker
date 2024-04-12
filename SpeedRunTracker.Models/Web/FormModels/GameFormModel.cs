using System.ComponentModel.DataAnnotations;
using static SpeedRunTracker.Common.EntityValidataions.GameValidations;

namespace SpeedRunTracker.Models.Web.FormModels
{
    public class GameFormModel
    {
        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLength, ErrorMessage = "Title must be between {2} and {1} letters long.")]
        [Display(Name = "Game title")]
        public string GameTitle { get; set; } = null!;

        [Required]
        [MaxLength(ImgUrlMaxLength)]
        [Url]
        [Display(Name = "Game image link")]
        public string ImgUrl { get; set; } = null!;

        [Required]
        public string UnmodifiedCategoryString { get; set; } = null!;

        [Required]
        public string UnmodifiedGenreString { get; set; } = null!;

        public IEnumerable<string>? CategoryNames { get; set; }
        
        public IEnumerable<string>? GenreTypes { get; set; } 
    }
}
