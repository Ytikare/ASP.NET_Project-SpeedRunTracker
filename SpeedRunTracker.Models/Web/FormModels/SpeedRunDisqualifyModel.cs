using SpeedRunTracker.Models.Web.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SpeedRunTracker.Common.EntityValidataions.SpeedRunValidations;

namespace SpeedRunTracker.Models.Web.FormModels
{
    public  class SpeedRunDisqualifyModel
    {
        public SpeedRunDetailsViewModel? SpeedRunDetails { get; set; }

        [DisplayName("Disqulification Reason")]
        [StringLength(MaxDisqualificationReasonLenght, MinimumLength = MinDisqualificationReasonLenght, ErrorMessage = "Disqualification reason must be between {2} and {1} symbols long.")]
        public string? DisqulificationMessage { get; set; } 
    }
}
