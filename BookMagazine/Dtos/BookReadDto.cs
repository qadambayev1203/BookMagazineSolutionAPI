using BookMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMagazine.Dtos
{
    public class BookReadDto
    {
        public int id { get; set; }

        public string bookName { get; set; }

        public string Author { get; set; }

        public DateTime dateManufacture { get; set; }

        public Language bookLanguage { get; set; }
    }
}
