using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
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
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
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
                GetBookIdQuery query = new GetBookIdQuery(_context,_mapper);
                query.Bookid = id;
                GetBookIdQueryValidator validator = new GetBookIdQueryValidator();
                validator.ValidateAndThrow(query);
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
            CreateBookCommand createBookCommand = new CreateBookCommand(_context,_mapper);
            try
            {
                createBookCommand.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(createBookCommand);
                createBookCommand.Handle();
                /*
                if (!result.IsValid)
                {
                    foreach (var item in result.Errors)
                    {
                        Console.WriteLine("Özellik: " + item.PropertyName + "- Eror Message: " + item.ErrorMessage);
                    }
                }
                else
                */
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
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
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
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
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
