using System.ComponentModel.DataAnnotations;

namespace SpeedRunTracker.Data.Entities
{
    using static Common.EntityValidataions.GameValidations;
    public class Game
    {
        public Game()
        {
            this.SpeedRuns = new HashSet<SpeedRun>();
            this.Genres = new HashSet<GameGenres>();
            this.Categories = new HashSet<GameCategories>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        public virtual ICollection<SpeedRun> SpeedRuns { get; set; }

        public ICollection<GameGenres> Genres { get; set; }

        public ICollection<GameCategories> Categories { get; set; }

        [Required]
        [MaxLength(ImgUrlMaxLength)]
        [Url]
        public string ImgUrl { get; set; } = null!;

    }
}
