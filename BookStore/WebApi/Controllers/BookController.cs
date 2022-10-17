using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;

            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = id;

            //Validation
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.Validate(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);

            command.Model = newBook;

            //Validation
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.Validate(command);
            command.Handle();

            //try 
            //{
            //    ValidationResult result = new ValidationResult(); //Validation sonuçlarý için
            //    if (!result.IsValid)
            //    {
            //        foreach (var item in result.Errors)
            //        {
            //            Console.WriteLine("Property" + item.PropertyName + "-Error Message: " + item.ErrorMessage);
            //        }
            //    }
            //}
            //catch (Exception ex) 
            //{
            //    return BadRequest(ex.Message);
            //}            

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);

            command.BookId = id;
            command.Model = updatedBook;

            //Validation
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.Validate(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);

            command.BookId = id;

            //Validation
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.Validate(command);

            command.Handle();

            return Ok();
        }
    }
}