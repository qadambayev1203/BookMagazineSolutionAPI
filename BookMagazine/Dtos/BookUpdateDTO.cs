﻿using BookMagazine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMagazine.Dtos
{
    public class BookUpdateDTO
    {
        [Required]
        [MaxLength(250)]
        public string bookName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Author { get; set; }

        public DateTime dateManufacture { get; set; }

        public Language bookLanguage { get; set; }
    }
}
