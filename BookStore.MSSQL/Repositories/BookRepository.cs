using AutoMapper;
using BookStore.Domain.Abstractions;
using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.MSSQL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Buy a book
        /// </summary>
        /// <param name="bookId"> Book Id </param>
        /// <returns> purchase confirm </returns>
        public bool Buy(int bookId)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
                throw new Exception("Book does not exist");

            _context.Books.Remove(book);
            _context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Get all books from database
        /// </summary>
        /// <returns> list of books </returns>
        public List<Book> Get()
        {
            return _context.Books
                           .Select(x => _mapper.Map<Book>(x))
                           .ToList();
        }

        /// <summary>
        /// Get books by title from database
        /// </summary>
        /// <param name="title"> title of the book </param>
        /// <returns> list of books </returns>
        public List<Book> GetByTitle(string title)
        {
            return _context.Books
                           .Where(x => x.Title.Contains(title))
                           .Select(x => _mapper.Map<Book>(x))
                           .ToList();
        }

        /// <summary>
        /// Get books by author from database
        /// </summary>
        /// <param name="author"></param>
        /// <returns> list of books </returns>
        public List<Book> GetByAuthor(string author)
        {
            return _context.Books
                           .Where(x => x.Author.Equals(author))
                           .Select(x => _mapper.Map<Book>(x))
                           .ToList();
        }

        /// <summary>
        /// Get books by date from database
        /// </summary>
        /// <param name="date"></param>
        /// <returns> list of books </returns>
        public List<Book> GetByDate(string date)
        {
            return _context.Books
                           .Where(x => x.Date.Equals(date))
                           .Select(x => _mapper.Map<Book>(x))
                           .ToList();
        }
    }
}
