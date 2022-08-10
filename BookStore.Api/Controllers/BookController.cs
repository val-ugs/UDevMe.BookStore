using BookStore.Domain.Abstractions;
using BookStore.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    /// <summary>
    /// Book Controller performs actions with books
    /// </summary>
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Buy a book
        /// </summary>
        /// <param name="id"> Book Id </param>
        /// <returns> purchase confirm </returns>
        [HttpPost]
        public ActionResult<bool> Buy([FromForm] int? id)
        {
            try
            {
                if (id != null)
                {
                    var result = _bookService.Buy(id.Value);

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound("Book not found");
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns> list of books </returns>
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return _bookService.Get();
        }

        /// <summary>
        /// Get books by title
        /// </summary>
        /// <param name="title"> title of the book </param>
        /// <returns> list of books </returns>
        [HttpGet("byTitle")]
        public ActionResult<List<Book>> GetByTitle(string? title)
        {
            try
            {
                if (title != null)
                {
                    var result = _bookService.GetByTitle(title);

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound("Book not found");
        }

        /// <summary>
        /// Get books by author
        /// </summary>
        /// <param name="author"></param>
        /// <returns> list of books </returns>
        [HttpGet("byAuthor")]
        public ActionResult<List<Book>> GetByAuthor(string? author)
        {
            try
            {
                if (author != null)
                {
                    var result = _bookService.GetByAuthor(author);

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound("Book not found");
        }

        /// <summary>
        /// Get books by date
        /// </summary>
        /// <param name="date"></param>
        /// <returns> list of books </returns>
        [HttpGet("byDate")]
        public ActionResult<List<Book>> GetByDate(string? date)
        {
            try
            {
                if (date != null)
                {
                    var result = _bookService.GetByDate(date);

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NotFound("Book not found");
        }
    }
}
