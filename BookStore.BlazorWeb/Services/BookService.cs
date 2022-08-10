using BookStore.BlazorWeb.Abstractions;
using BookStore.BlazorWeb.Models;

namespace BookStore.BlazorWeb.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Buy a book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns> purchase confirm </returns>
        public async Task<bool> BuyAsync(int bookId)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("id", bookId.ToString())
            });

            HttpResponseMessage response = await _httpClient.PostAsync("books", content);

            if (response.IsSuccessStatusCode == false)
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns> list of books </returns>
        public async Task<List<Book>> GetAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("books");
                
            if (response.IsSuccessStatusCode == false)
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            
            return await response.Content.ReadAsAsync<List<Book>>();
        }

        /// <summary>
        /// Get books by title
        /// </summary>
        /// <param name="title"> title of the book </param>
        /// <returns> list of books </returns>
        public async Task<List<Book>> GetByTitleAsync(string title)
        {
            return await GetByAsync("byTitle?title=", title);
        }

        /// <summary>
        /// Get books by author
        /// </summary>
        /// <param name="author"></param>
        /// <returns> list of books </returns>
        public async Task<List<Book>> GetByAuthorAsync(string author)
        {
            return await GetByAsync("byAuthor?author=", author);
        }

        /// <summary>
        /// Get books by date
        /// </summary>
        /// <param name="date"></param>
        /// <returns> list of books </returns>
        public async Task<List<Book>> GetByDateAsync(string date)
        {
            return await GetByAsync("byDate?date=", date);
        }

        /// <summary>
        /// Get books based on request
        /// </summary>
        /// <returns> list of books </returns>
        private async Task<List<Book>> GetByAsync(string query, string value)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("books/" + query + value);

            if (response.IsSuccessStatusCode == false)
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            return await response.Content.ReadAsAsync<List<Book>>();
        }
    }
}
