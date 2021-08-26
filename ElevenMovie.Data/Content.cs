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
    public class Content
    {
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
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
        [ForeignKey(nameof(Genre))]
        public int AssignedGenre { get; set; }
        public virtual Genre Genre { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }



        //public Content() { }
        //public Content(string title, string description, MaturityRating typeOfMaturityRating, string genre, bool isStarred, DateTimeOffset createdUtc, DateTimeOffset modifiedUtc)
        //{
        //    Title = title;
        //    Description = description;
        //    TypeOfMaturityRating = typeOfMaturityRating;
        //    Genre = genre;
        //    IsStarred = isStarred;
        //    CreatedUtc = createdUtc;
        //    ModifiedUtc = modifiedUtc;
        //}
        public class MyListModel
        {
            public string SelectedItemId { get; set; }
            public IEnumerable<Genre> Items { get; set; }
        }










    }
}
