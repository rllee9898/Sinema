using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Data
{
    public class Review
    {
        [Required]
        [Display(Name = "Owner Id")]
        public Guid OwnerId { get; set; }

        [Display(Name = "Review Id")]
        public int ReviewId { get; set; }


        [Display(Name = "Reviewer")]
        public string Reviewer { get; set; }


        [Display(Name = "Title")]
        public string Title { get; set; }


        [Display(Name = "Rating")]
        public int Rating { get; set; }


        [Display(Name = "Content")]
        public string Content { get; set; }


        [DefaultValue(false)]
        public bool IsStarred { get; set; }


        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
