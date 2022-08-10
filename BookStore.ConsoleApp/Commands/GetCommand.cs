using BookStore.ConsoleApp.Models;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookStore.ConsoleApp.Commands
{
    [Verb("get", HelpText = "Get Books")]
    public class GetCommand : ICommand
    {
        [Option("title", HelpText = "title of the book")]
        public string Title { get; set; }
        [Option("author", HelpText = "author of the book")]
        public string Author { get; set; }
        [Option("date", HelpText = "date of the book")]
        public string Date { get; set; }
        [Option("order-by", HelpText = "order by [title|author|date]")]
        public string OrderByValue { get; set; }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            List<Book> books = null;
            
            var words = parameter as String[];

            try
            {
                if (words.Length == 1)
                    books = GetAsync().Result;
                else if (words.Length > 1)
                {
                    var s = string.Concat(words);
                    if (s.Contains("--title")) books = GetByTitleAsync().Result;
                    else if (s.Contains("--author")) books = GetByAuthorAsync().Result;
                    else if (s.Contains("--date")) books = GetByDateAsync().Result;

                    if (s.Contains("--order-by"))
                    {
                        if (books == null)
                            books = GetAsync().Result;

                        books = OrderBy(books);
                    }
                }

                if (books == null)
                    Console.WriteLine("Request error");
                
                if (books.Count() == 0)
                {
                    Console.WriteLine("There are no books in the store");
                    return;
                }

                Console.WriteLine("Books:");
                for (int i = 0; i < books.Count; i++)
                {
                    var book = books[i];
                    Console.WriteLine(string.Format("Id: {0}", book.Id));
                    Console.WriteLine(string.Format("Title: {0}", book.Title));
                    Console.WriteLine(string.Format("Author: {0}", book.Author));
                    Console.WriteLine(string.Format("Date: {0}", book.Date));
                    Console.WriteLine();
                }
            }
            catch (AggregateException ex)
            {
                foreach (var exInner in ex.InnerExceptions)
                    Console.WriteLine(exInner.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns> list of books </returns>
        private async Task<List<Book>> GetAsync()
        {
            HttpResponseMessage response = await HttpClientSample.HttpClient.GetAsync("books");

            if (response.IsSuccessStatusCode == false)
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            
            return await response.Content.ReadAsAsync<List<Book>>();
        }

        /// <summary>
        /// Get books by title
        /// </summary>
        /// <returns> list of books </returns>
        private async Task<List<Book>> GetByTitleAsync()
        {
            return await GetByAsync("byTitle?title=", Title);
        }

        /// <summary>
        /// Get books by author
        /// </summary>
        /// <returns> list of books </returns>
        private async Task<List<Book>> GetByAuthorAsync()
        {
            return await GetByAsync("byAuthor?author=", Author);
        }

        /// <summary>
        /// Get books by date
        /// </summary>
        /// <returns> list of books </returns>
        private async Task<List<Book>> GetByDateAsync()
        {
            return await GetByAsync("byDate?date=", Date);
        }

        /// <summary>
        /// Get books based on request
        /// </summary>
        /// <returns> list of books </returns>
        private async Task<List<Book>> GetByAsync(string query, string value)
        {
            // remove quotes from value
            if (string.IsNullOrEmpty(value))
                throw new Exception("Value is not set");

            value = value.Replace("\"", string.Empty);
            
            HttpResponseMessage response = await HttpClientSample.HttpClient.GetAsync("books/" + query + value);

            if (response.IsSuccessStatusCode == false)
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            
            return await response.Content.ReadAsAsync<List<Book>>();
        }

        /// <summary>
        /// Sort books by value
        /// </summary>
        /// <param name="books"> list of books </param>
        /// <returns> list of books </returns>
        private List<Book> OrderBy(List<Book> books)
        {
            if (books != null)
            {
                if (string.IsNullOrEmpty(OrderByValue))
                    throw new Exception("Value is not set");

                // remove quotes from OrderByValue
                string value = OrderByValue.Replace("\"", string.Empty);

                if (value == "title") return books.OrderBy(b => b.Title).ToList();
                else if (value == "author") return books.OrderBy(b => b.Author).ToList();
                else if (value == "date") return books.OrderBy(b => b.Date).ToList();
            }
            
            return null;
        }
    }
}
