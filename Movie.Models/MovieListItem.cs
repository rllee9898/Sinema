using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class MovieListItem
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        [Display(Name = "Created")]

        public bool IsStarred { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
