﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Data
{
    public class Movie : Content
    {
        [Key]
        public int MovieId { get; set; }
    }
}