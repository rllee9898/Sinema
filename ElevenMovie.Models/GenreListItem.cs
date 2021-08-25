using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class GenreListItem
    {
        [Display(Name = "Genre Id")]
        public int GenreId { get; set; }

        [Key]
        [Display(Name = "Genre")]
        public string GenreType { get; set; }

        [UIHint("Starred")]
        [Display(Name = "Favorite")]
        public bool IsStarred { get; set; }
    }
}