using BookStore.BusinessLogic.Services;
using BookStore.Domain.Abstractions;
using BookStore.Domain.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookStore.Tests
{
    public class Tests
    {
        private BookService _bookService;
        private Mock<IBookRepository> _bookRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();

            _bookService = new BookService(_bookRepositoryMock.Object);
        }

        [Test]
        public void Buy_ShouldReturnTrue()
        {
            // arrange
            var bookId = 1;

            _bookRepositoryMock
                .Setup(x => x.Buy(It.IsAny<int>()))
                .Returns(true)
                .Verifiable();

            // act
            var result = _bookService.Buy(bookId);

            // assert
            _bookRepositoryMock.Verify(x => x.Buy(bookId), Times.Once());

            Assert.IsTrue(result);
        }

        [Test]
        public void Get_ShouldReturnTrue()
        {
                // arrange
                List<Book> books = new List<Book>()
                {
                    new Book
                    {
                        Id = 1,
                        Author = "Л. Н. Толстой",
                        Title = "Война и мир",
                        Date = DateTime.Now.ToString("yyyy-MM-dd")
                    },
                    new Book
                    {
                        Id = 2,
                        Author = "Ф. М. Достоевский",
                        Title = "Преступление и наказание",
                        Date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
                    }
                };
                _bookRepositoryMock.Setup(x => x.Get())
                               .Returns(() => books)
                               .Verifiable();

            // act
            var result = _bookService.Get();

            // assert
            _bookRepositoryMock.Verify(x => x.Get(), Times.Once);
            Assert.IsTrue(result == books);
        }

        [Test]
        public void GetByTitle_ShouldReturnTrue()
        {
            // arrange
            string title = "Война и мир";
            List<Book> books = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Author = "Л. Н. Толстой",
                    Title = title,
                    Date = DateTime.Now.ToString("yyyy-MM-dd")
                },
                new Book
                {
                    Id = 2,
                    Author = "Л. Н. Толстой",
                    Title = title,
                    Date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
                }
            };

            _bookRepositoryMock.Setup(x => x.GetByTitle(title))
                               .Returns(() => books)
                               .Verifiable();

            // act
            var result = _bookService.GetByTitle(title);

            // assert
            _bookRepositoryMock.Verify(x => x.GetByTitle(title), Times.Once);
            Assert.IsTrue(result == books);
        }

        [Test]
        public void GetByTitle_DoesNotSet_ShouldThrowException()
        {
            // arrange
            string title = "";
            List<Book> result = null;

            _bookRepositoryMock.Setup(x => x.GetByTitle(It.Is<string>(y => y == title)))
                               .Returns(() => new List<Book>())
                               .Verifiable();

            // act
            // assert
            Assert.Throws<Exception>(() => result = _bookService.GetByTitle(title));
            _bookRepositoryMock.Verify(x => x.GetByTitle(title), Times.Never);
            Assert.IsNull(result);
        }

        [Test]
        public void GetByTitle_NotFound_ShouldThrowException()
        {
            // arrange
            string title = "Война и мир";
            List<Book> result = null;

            _bookRepositoryMock.Setup(x => x.GetByTitle(It.Is<string>(y => y == title)))
                               .Returns(() => new List<Book>())
                               .Verifiable();

            // act
            // assert
            Assert.Throws<Exception>(() => result = _bookService.GetByTitle(title));
            _bookRepositoryMock.Verify(x => x.GetByTitle(title), Times.Once);
            Assert.IsNull(result);
        }

        [Test]
        public void GetByAuthor_ShouldReturnTrue()
        {
            // arrange
            string author = "Л. Н. Толстой";
            List<Book> books = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Author = author,
                    Title = "Война и мир",
                    Date = DateTime.Now.ToString("yyyy-MM-dd")
                },
                new Book
                {
                    Id = 2,
                    Author = author,
                    Title = "Война и мир",
                    Date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
                }
            };

            _bookRepositoryMock.Setup(x => x.GetByAuthor(author))
                               .Returns(() => books)
                               .Verifiable();

            // act
            var result = _bookService.GetByAuthor(author);

            // assert
            _bookRepositoryMock.Verify(x => x.GetByAuthor(author), Times.Once);
            Assert.IsTrue(result == books);
        }

        [Test]
        public void GetByAuthor_DoesNotSet_ShouldThrowException()
        {
            // arrange
            string author = "";
            List<Book> result = null;

            _bookRepositoryMock.Setup(x => x.GetByAuthor(It.Is<string>(y => y == author)))
                               .Returns(() => new List<Book>())
                               .Verifiable();

            // act
            // assert
            Assert.Throws<Exception>(() => result = _bookService.GetByAuthor(author));
            _bookRepositoryMock.Verify(x => x.GetByAuthor(author), Times.Never);
            Assert.IsNull(result);
        }

        [Test]
        public void GetByAuthor_NotFound_ShouldThrowException()
        {
            // arrange
            string author = "Л. Н. Толстой";
            List<Book> result = null;

            _bookRepositoryMock.Setup(x => x.GetByAuthor(It.Is<string>(y => y == author)))
                               .Returns(() => new List<Book>())
                               .Verifiable();

            // act
            // assert
            Assert.Throws<Exception>(() => result = _bookService.GetByAuthor(author));
            _bookRepositoryMock.Verify(x => x.GetByAuthor(author), Times.Once);
            Assert.IsNull(result);
        }

        [Test]
        public void GetByDate_ShouldReturnTrue()
        {
            // arrange
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<Book> books = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Author = "Л. Н. Толстой",
                    Title = "Война и мир",
                    Date = date
                }
            };

            _bookRepositoryMock.Setup(x => x.GetByDate(date))
                               .Returns(() => books)
                               .Verifiable();

            // act
            var result = _bookService.GetByDate(date);

            // assert
            _bookRepositoryMock.Verify(x => x.GetByDate(date), Times.Once);
            Assert.IsTrue(result == books);
        }

        [Test]
        public void GetByDate_DoesNotSet_ShouldThrowException()
        {
            // arrange
            string date = "";
            List<Book> result = null;

            _bookRepositoryMock.Setup(x => x.GetByDate(It.Is<string>(y => y == date)))
                               .Returns(() => new List<Book>())
                               .Verifiable();

            // act
            // assert
            Assert.Throws<Exception>(() => result = _bookService.GetByDate(date));
            _bookRepositoryMock.Verify(x => x.GetByDate(date), Times.Never);
            Assert.IsNull(result);
        }

        [Test]
        public void GetByDate_Format_ShouldThrowException()
        {
            // arrange
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            List<Book> result = null;

            _bookRepositoryMock.Setup(x => x.GetByDate(It.Is<string>(y => y == date)))
                               .Returns(() => new List<Book>())
                               .Verifiable();

            // act
            // assert
            Assert.Throws<Exception>(() => result = _bookService.GetByDate(date));
            _bookRepositoryMock.Verify(x => x.GetByDate(date), Times.Never);
            Assert.IsNull(result);
        }

        [Test]
        public void GetByDate_NotFound_ShouldThrowException()
        {
            // arrange
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<Book> result = null;

            _bookRepositoryMock.Setup(x => x.GetByDate(It.Is<string>(y => y == date)))
                               .Returns(() => new List<Book>())
                               .Verifiable();

            // act
            // assert
            Assert.Throws<Exception>(() => result = _bookService.GetByDate(date));
            _bookRepositoryMock.Verify(x => x.GetByDate(date), Times.Once);
            Assert.IsNull(result);
        }
    }
}