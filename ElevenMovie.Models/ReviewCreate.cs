using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class ReviewCreate
    {
        [Display(Name = "Reviewer Id")]
        public int ReviewId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Reviewers Name")]
        public string Reviewer { get; set; }

        [Display(Name = "Content")]
        public string Content { get; set; }

        //[Display(Name = "Created")]
        //public DateTimeOffset CreatedUtc { get; set; }
    }
}