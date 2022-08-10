using BookStore.Domain.Abstractions;
using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Buy a book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns> purchase confirm </returns>
        public bool Buy(int bookId)
        {
            return _bookRepository.Buy(bookId);
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns> list of books </returns>
        public List<Book> Get()
        {
            return _bookRepository.Get();
        }

        /// <summary>
        /// Get books by title
        /// </summary>
        /// <param name="title"> title of the book </param>
        /// <returns> list of books </returns>
        public List<Book> GetByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception("Title does not set");

            var books = _bookRepository.GetByTitle(title);

            if (books.Count() == 0)
                throw new Exception(string.Format("There are no books containing the title \"{0}\"", 
                                                  title));

            return books;
        }

        /// <summary>
        /// Get books by author
        /// </summary>
        /// <param name="author"></param>
        /// <returns> list of books </returns>
        public List<Book> GetByAuthor(string author)
        {
            if (string.IsNullOrEmpty(author))
                throw new Exception("Author does not set");

            var books = _bookRepository.GetByAuthor(author);

            if (books.Count() == 0)
                throw new Exception(string.Format("There are no books containing the author \"{0}\"", 
                                                  author));

            return books;
        }

        /// <summary>
        /// Get books by date
        /// </summary>
        /// <param name="date"></param>
        /// <returns> list of books </returns>
        public List<Book> GetByDate(string date)
        {
            DateTime dt;
            const string format = "yyyy-MM-dd";

            if (string.IsNullOrEmpty(date))
                throw new Exception("Date does not set");

            if (DateTime.TryParseExact(date, format,
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out dt) == false)
                throw new Exception(string.Format("Invalid date format. Correct date format: {0}", format));

            var books = _bookRepository.GetByDate(date);

            if (books.Count() == 0)
                throw new Exception(string.Format("There are no books containing the date \"{0}\"", 
                                                  date));

            return books;
        }
    }
}
