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
    public class ShowDetail
    {
        [Display(Name = "Show Id")]
        public int ShowId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [ForeignKey(nameof(Genre))]
        public string GenreType { get; set; }
        public virtual Genre Genre { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Season Count")]
        public int SeasonCount { get; set; }

        [Display(Name = "Episode Count")]
        public int EpisodeCount { get; set; }

        [Display(Name = "Average Run Time")]
        public double AverageRunTime { get; set; }

        [Display(Name = "Air Date")]
        public DateTime AirDate { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}