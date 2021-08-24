using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class GenreCreate
    {
        [Display(Name = "Genre Type")]
        public string GenreType { get; set; }
    }
}