using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Data
{
    public class Review
    {
        public int Id { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Created")]
        public string CreatedAt { get; set; }
    }
}
