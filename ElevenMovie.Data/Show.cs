using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Data
{
    public class Show : Content
    {
        [Key]
        public int ShowId { get; set; }

        [Display(Name = "Season Count")]
        public int SeasonCount { get; set; }

        [Display(Name = "Episode Count")]
        public int EpisodeCount { get; set; }

        [Display(Name = "Average Run Time")]
        public double AverageRunTime { get; set; }

        [Display(Name = "Air Date")]
        public int AirDate { get; set; }

    }
}
