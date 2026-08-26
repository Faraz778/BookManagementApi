using Microsoft.AspNetCore.Mvc;
using BookManagementApi.DTOs;
using BookManagementApi.Services;

namespace BookManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto bookdto)
        {
            var result = await _bookService.CreateBookAsync(bookdto);
            return Created("", result);

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
