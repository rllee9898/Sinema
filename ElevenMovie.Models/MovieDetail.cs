using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class MovieDetail
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

        [Display(Name = "Movie ID")]
        public int MovieId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Genre")]
        public int AssignedGenre { get; set; }

        [Display(Name = "Family Friendly")]
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

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        [Display(Name = "Favorite")]
        public bool IsStarred { get; set; }
    }
}