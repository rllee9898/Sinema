using ElevenMovie.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class ShowEdit
    {
        [Display(Name = "Show Id")]
        public int ShowId { get; set; }

        [Required]
        [Display(Name = "Title")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        
        [Display(Name = "Favorite")]
        public bool IsStarred { get; set; }

        [Display(Name = "Season Count")]
        public int SeasonCount { get; set; }

        [Display(Name = "Episode Count")]
        public int EpisodeCount { get; set; }

        [Display(Name = "Average Run Time")]
        public double AverageRunTime { get; set; }

        [Display(Name = "Air Date")]
        public int AirDate { get; set; }
        
        public int AssignedGenre { get; set; }
    }
}
