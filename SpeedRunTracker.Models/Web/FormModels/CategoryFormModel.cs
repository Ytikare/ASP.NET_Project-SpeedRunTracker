using System.ComponentModel.DataAnnotations;
using static SpeedRunTracker.Common.EntityValidataions.CategoryValidations;
namespace SpeedRunTracker.Models.Web.FormModels
{
    public class CategoryFormModel
    {
        [Required]
        [Display(Name = "Category name")]
        [StringLength(MaxNameLenght, MinimumLength = MinNameLenght, ErrorMessage = "Name lenght must be between {2} and {1} characters long.")]
        public string CategoryName { get; set; } = null!;
    }
}
