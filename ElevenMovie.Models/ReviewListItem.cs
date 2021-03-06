using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class ReviewListItem
    {
        [Display(Name = "Reviewer Id")]
        public int ReviewId { get; set; }

        [Display(Name = "Reviewer")]
        public string Reviewer { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Display(Name = "Review")]
        public string Content { get; set; }

        [UIHint("Starred")]
        [Display(Name = "Favorite")]
        public bool IsStarred { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}