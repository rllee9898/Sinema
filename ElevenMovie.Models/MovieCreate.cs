using ElevenMovie.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class MovieCreate
    {
        public enum MaturityRating
        {
            G = 1,
            PG,
            PG_13,
            R,
            NC_17,
            TV_G,
            TV_MA
        }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [MaxLength(8000)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Is Family Friendly")]
        public bool IsFamilyFriendly
        {
            get
            {
                switch (TypeOfMaturityRating)
                {
                    case MaturityRating.G:
                    case MaturityRating.PG:
                    case MaturityRating.TV_G:
                        return true;
                    case MaturityRating.PG_13:
                    case MaturityRating.R:
                    case MaturityRating.NC_17:
                    case MaturityRating.TV_MA:
                    default:
                        return false;
                }
            }
        }
        [Display(Name = "Type Of Maturity Rating")]
        public MaturityRating TypeOfMaturityRating { get; set; }

        [Required]
        [Display(Name = "Genre")]
        [ForeignKey(nameof(Genre))]
        public string GenreType { get; set; }
        public virtual Genre Genre { get; set; }
        //Put Foriegn key here in base class

        [DefaultValue(false)]
        [Display(Name = "Is Starred")]
        public bool IsStarred { get; set; }
    }
}
