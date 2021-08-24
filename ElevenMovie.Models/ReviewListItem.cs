﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenMovie.Models
{
    public class ReviewListItem
    {
        [Display(Name = "Reviewer Id")]
        public int ReviewId { get; set; }

        [Display(Name = "Reviewer")]
        public string Reviewer { get; set; }

        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Created")]
        public string CreatedAt { get; set; }
    }
}