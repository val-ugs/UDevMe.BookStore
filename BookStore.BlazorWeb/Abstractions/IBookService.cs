using BookStore.BlazorWeb.Models;

namespace BookStore.BlazorWeb.Abstractions
{
    public interface IBookService
    {
        Task<bool> BuyAsync(int bookId);
        Task<List<Book>> GetAsync();
        Task<List<Book>> GetByTitleAsync(string title);
        Task<List<Book>> GetByAuthorAsync(string author);
        Task<List<Book>> GetByDateAsync(string date);
    }
}
