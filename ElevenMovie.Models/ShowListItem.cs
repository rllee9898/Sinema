using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class ShowListItem
    {
        public int ShowId { get; set; }
        [Display(Name = "Season Count")]
        public int SeasonCount { get; set; }

        [Display(Name = "Episode Count")]
        public int EpisodeCount { get; set; }

        [Display(Name = "Air Date")]
        public DateTime AirDate { get; set; }
    
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
