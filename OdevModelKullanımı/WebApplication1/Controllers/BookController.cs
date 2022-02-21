using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BookOperations.CreateBook;
using WebApplication1.BookOperations.DeleteBook;
using WebApplication1.BookOperations.GetBookId;
using WebApplication1.BookOperations.GetBooks;
using WebApplication1.BookOperations.UpdateBook;
using WebApplication1.DBOperations;
using static WebApplication1.BookOperations.CreateBook.CreateBookCommand;
using static WebApplication1.BookOperations.UpdateBook.UpdateBookCommand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BooksIdViewModel result;
            try
            {
                GetBookIdQuery query = new GetBookIdQuery(_context);
                query.Bookid = id;
                result=query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand createBookCommand = new CreateBookCommand(_context);
            try
            {
                createBookCommand.Model = newBook;
                createBookCommand.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(); 
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult  UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.Bookid = id;
                command.model = updateBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
