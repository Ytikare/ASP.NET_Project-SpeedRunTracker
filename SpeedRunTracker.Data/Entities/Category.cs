﻿using System.ComponentModel.DataAnnotations;

namespace SpeedRunTracker.Data.Entities
{
    using static Common.EntityValidataions.CategoryValidations;
    public class Category
    {
        public Category()
        {
            Games = new HashSet<GameCategories>();
            SpeedRuns = new HashSet<SpeedRun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLenght)]
        public string Name { get; set; } = null!;

        public ICollection<GameCategories> Games { get; set; }

        public ICollection<SpeedRun> SpeedRuns { get; set; }
    }
}
