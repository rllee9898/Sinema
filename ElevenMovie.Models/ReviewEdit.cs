using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class ReviewEdit
    {
        [Display(Name = "Reviewer Id")]
        public int ReviewId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Name")]
        public string Reviewer { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Favorite")]
        public bool IsStarred { get; set; }

    }
}
