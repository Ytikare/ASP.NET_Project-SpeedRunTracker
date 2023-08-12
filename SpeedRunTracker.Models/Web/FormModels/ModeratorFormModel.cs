using System.ComponentModel.DataAnnotations;

namespace SpeedRunTracker.Models.Web.FormModels
{
    public class ModeratorFormModel
    {

        [Required]
        public string Id { get; set; } = null!;
        
        public string? Username { get; set; }
    }
}
