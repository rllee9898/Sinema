using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Data
{
    public class Movie : Content
    {
        [Key]
        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }

    }
}
