using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Data
{
    public class Genre
    {
        [Display(Name = "Genre Id")]
        public int Id { get; set; }

        [Key]
        [Display(Name = "Genre Type")]
        public string GenreType { get; set; }
        
    }
}