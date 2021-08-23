using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Data
{
    public class List
    {
        [Required]
        [Display(Name = "Owner Id")]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Public")]
        public bool Public { get; set; }

        [Display(Name = "Movie")]
        public List Movies { get; set; }
    }
}
