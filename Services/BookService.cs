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
            // DTO se data lekar Book entity ka naya object banata hai
            var book = new Book
            {
                Title = createBookDto.Title, // DTO ka Title Book ke Title mein copy karta hai
                Author = createBookDto.Author, // DTO ka Author Book ke Author mein copy karta hai
                PublishedYear = createBookDto.PublishedYear // DTO ka PublishedYear Book mein copy karta hai
            };

            await _context.Books.AddAsync(book); // Book ko database mein add karne ke liye mark karta hai
            await _context.SaveChangesAsync(); // Changes ko actual database mein save karta hai
            var bookResponse = new BookResponseDto
            {
                Id = book.Id, // Book ka Id BookResponseDto mein copy karta hai
                Title = book.Title, // Book ka Title BookResponseDto mein copy karta hai
                Author = book.Author, // Book ka Author BookResponseDto mein copy karta hai
                PublishedYear = book.PublishedYear // Book ka PublishedYear BookResponseDto mein copy karta hai
            };


            return bookResponse; // 201 Created response ke saath newly created Book return karta hai		}
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
            var existing = await _context.Books.FindAsync(id);  // id find kro
            if (existing == null)      // agr id nhi mili to 404 return kro
            {
                return false;
            }

            _context.Books.Remove(existing); // id wala record delete kro

            await _context.SaveChangesAsync(); // changes save kro db me
            return true;  // delete hone ke baad deleted record return kro		
        }


    }
}
