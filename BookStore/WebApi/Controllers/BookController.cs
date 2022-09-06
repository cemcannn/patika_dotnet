using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.DBOperations;
using System;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.GetBookDetail;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using WebApi.BookOperations.DeleteBook;
using FluentValidation.Results;

namespace WebApi.AddControllers 
{
    [ApiController] 
    [Route("[controller]s")] 
    public class BookController : ControllerBase 
    {
        private readonly BookStoreDbContext _context; 

        public BookController (BookStoreDbContext context) 
        {
            _context = context; 
        }
        
        [HttpGet]
        public IActionResult GetBooks() 
        {
            GetBooksQuery query = new GetBooksQuery(_context); 
            var result = query.Handle(); 
            return Ok(result); 
        }

        [HttpGet("{id}")] 
        public IActionResult GetById(int id) 
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.Validate(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook) 
        {
            CreateBookCommand command = new CreateBookCommand(_context); 
            try 
            {
                command.Model = newBook;

                //Validation
                ValidationResult result = new ValidationResult(); //Validation sonuçlarý için
                if (!result.IsValid)
                {
                    foreach (var item in result.Errors)
                    {
                        Console.WriteLine("Property" + item.PropertyName + "-Error Message: " + item.ErrorMessage);
                    }
                }

                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.Validate(command);
                command.Handle(); 
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }            

            return Ok(); 
        }

        [HttpPut("{id}")] 
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.BookId = id;
                command.Model = updatedBook;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.Validate(command);
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }  
            return Ok();
        }
        
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.BookId = id;

                //Validation
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.Validate(command);

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