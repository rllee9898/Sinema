using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
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
        public string Description { get; set; }

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
        public MaturityRating TypeOfMaturityRating { get; set; }

        [Required]
        public string Genre { get; set; }
        //Put Foriegn key here in base class

        [DefaultValue(false)]
        public bool IsStarred { get; set; }
    }
}
