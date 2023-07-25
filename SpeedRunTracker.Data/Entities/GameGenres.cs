using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedRunTracker.Data.Entities
{
    public class GameGenres
    {
        public int GenreId { get; set; }

        public int GameId { get; set; }


        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;
    }
}