using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Data
{
    public class Genre
    {
        [Required]
        [Display(Name = "Owner Id")]
        public Guid OwnerId { get; set; }

        [Key]
        [Display(Name = "Genre Id")]
        public int GenreId { get; set; }

        
        [Display(Name = "Genre")]
        public string GenreType { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }
    }
}