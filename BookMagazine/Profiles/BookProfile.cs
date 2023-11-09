using AutoMapper;
using BookMagazine.Dtos;
using BookMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMagazine.Profiles
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<BookCreateDTO, Book>();
            CreateMap<BookUpdateDTO, Book>();
            CreateMap<Book, BookReadDto>();
        }
    }
}
