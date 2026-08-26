using BookManagementApi.DTOs;
using BookManagementApi.Services;

namespace BookManagementApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDto>> GetAllBooksAsync();
        Task<BookResponseDto?> GetBookByIdAsync(int id);
        Task<BookResponseDto> CreateBookAsync(CreateBookDto createBookDto);
        Task<bool> UpdateBookAsync(int id, UpdateBookDto updateBookDto);
        Task<bool> DeleteBookAsync(int id);
    }
}