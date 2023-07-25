using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedRunTracker.Data.Entities
{
    public class GameCategories
    {
        public int CategoryId { get; set; }

        public int GameId { get; set; }


        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; } = null!;

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}