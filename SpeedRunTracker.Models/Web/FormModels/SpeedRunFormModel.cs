using System.ComponentModel.DataAnnotations;
using static SpeedRunTracker.Common.ModelsValidations.SpeedRunValidations;

namespace SpeedRunTracker.Models.Web.FormModels
{
    public class SpeedRunFormModel
    {
        [Display(Name = "Game Title")]
        public int GameId { get; set; }

        public virtual IEnumerable<SpeedRunSelectGameFormModel> Games { get; set; } = new HashSet<SpeedRunSelectGameFormModel>();

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual IEnumerable<SpeedRunSelectCategoryFormModel> Categories { get; set; } = new HashSet<SpeedRunSelectCategoryFormModel>();

        [Required]
        [Url]
        public string SpeedRunVideoUrl { get; set; } = null!;

        [Required]
        [Display(Name = "SpeedRun Time")]
        [RegularExpression(SpeedrunTimePattern, ErrorMessage = "Submition time doen not follow the pattern: hh:mm:ss.xxx")]
        public string SpeedRunTime { get; set; } = null!;
    }
}
