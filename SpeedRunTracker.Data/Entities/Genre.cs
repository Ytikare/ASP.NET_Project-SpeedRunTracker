using System.ComponentModel.DataAnnotations;

namespace SpeedRunTracker.Data.Entities
{
    using static Common.EntityValidataions.GenreValidations;
    public class Genre
    {
        public Genre()
        {
            Games = new HashSet<GameGenres>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTypeLenght)]
        public string Type { get; set; } = null!;

        public ICollection<GameGenres> Games { get; set; }
    }
}