using AutoMapper;
using BookStore.MSSQL.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BookStore.MSSQL.Tests
{
    public class BookRepositoryTests
    {
        private BookRepository _bookRepository;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<BookStoreContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookStoreDB;Trusted_Connection=True;")
                .Options;
            var context = new BookStoreContext(contextOptions);

            var configuration = new MapperConfiguration(x => x.AddProfile<DataAccessMappingProfile>());
            var mapper = new Mapper(configuration);

            _bookRepository = new BookRepository(context, mapper);
        }

        [Test]
        public void Get_ShouldReturnBook()
        {
            // arrange

            // act
            var books = _bookRepository.Get();

            // assert
            Assert.IsNotNull(books);
        }
    }
}
