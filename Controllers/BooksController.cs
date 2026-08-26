using BookManagementApi.Data;
using BookManagementApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookManagementApi.DTOs;
using BookManagementApi.Services;

namespace BookManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //private readonly AppDbContext _context;
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost] // POST request ko handle karta hai
        public async Task<IActionResult> CreateBook(CreateBookDto bookdto) // Request ka data CreateBookDto object mein receive karta hai
        {
            var result = await _bookService.CreateBookAsync(bookdto);
            return Created("", result); // 200 OK response return karta hai, jismein result object hota hai


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (result == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        // get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = await _bookService.GetBookByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _bookService.GetAllBooksAsync();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDto bookDto)
        {
            var result = await _bookService.UpdateBookAsync(id, bookDto);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();

        }



    }

}
