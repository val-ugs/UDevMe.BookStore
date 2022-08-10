using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Abstractions
{
    public interface IBookRepository
    {
        bool Buy(int bookId);
        List<Book> Get();
        List<Book> GetByTitle(string title);
        List<Book> GetByAuthor(string author);
        List<Book> GetByDate(string date);
    }
}
