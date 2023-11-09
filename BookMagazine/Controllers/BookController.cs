using AutoMapper;
using BookMagazine.Data;
using BookMagazine.Dtos;
using BookMagazine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMagazine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookAPIRepo _repository;

        private readonly IMapper _mapper;

        public BookController(IBookAPIRepo bookAPIRepo, IMapper mapper)
        {
            _repository = bookAPIRepo;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBook(BookCreateDTO bookCreateDTO)
        {
            var bookModel = _mapper.Map<Book>(bookCreateDTO);

            await _repository.CreateBook(bookModel);

            await _repository.SaveChangesAsync();

            var bookReadDto = _mapper.Map<BookReadDto>(bookModel);

            return Created("", bookReadDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _repository.GetAllBook();

            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));             
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _repository.GetBookByID(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookReadDto>(book));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var bookModelFromRepo = await _repository.GetBookByID(id);

            if (bookModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteBook(bookModelFromRepo);

            await _repository.SaveChangesAsync();

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookUpdateDTO bookUpdateDTO)
        {
            var bookModelFromRepo = await _repository.GetBookByID(id);

            if (bookModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(bookUpdateDTO, bookModelFromRepo);

            //await _repository.UpdateBook(bookModelFromRepo);

            await _repository.SaveChangesAsync();

            return Ok(_mapper.Map<BookReadDto>(bookModelFromRepo));
        }
    }
}
