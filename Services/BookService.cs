using BookManagementApi.Models;
using BookManagementApi.Data;
using BookManagementApi.DTOs;
using Microsoft.EntityFrameworkCore;


namespace BookManagementApi.Services
{
    public class BookService : IBookService
    {

        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookResponseDto>> GetAllBooksAsync()
        {
            var response = await _context.Books.Select(b => new BookResponseDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                PublishedYear = b.PublishedYear
            }).ToListAsync();

            return response;
        }

        public async Task<BookResponseDto?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return null;
            }

            var res = new BookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishedYear = book.PublishedYear
            };

            return res;
        }

        public async Task<BookResponseDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = new Book
            {
                Title = createBookDto.Title, 
                Author = createBookDto.Author, 
                PublishedYear = createBookDto.PublishedYear 

            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync(); 
           var bookResponse = new BookResponseDto
            {
                Id = book.Id,
                Title = book.Title, 
                Author = book.Author, 
                PublishedYear = book.PublishedYear
            };


            return bookResponse;
        }

        public async Task<bool> UpdateBookAsync(int id, UpdateBookDto updateBookDto)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                return false;
            }

            existingBook.Title = updateBookDto.Title;
            existingBook.Author = updateBookDto.Author;
            existingBook.PublishedYear = updateBookDto.PublishedYear;

            await _context.SaveChangesAsync();


            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var existing = await _context.Books.FindAsync(id);  
            if (existing == null)      
            {
                return false;
            }

            _context.Books.Remove(existing); 

            await _context.SaveChangesAsync(); 
            return true;  
        }


    }
}
