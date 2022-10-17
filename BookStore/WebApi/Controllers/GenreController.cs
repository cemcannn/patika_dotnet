using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApi.DBOperations;
using WebApi.GenreOperations.CreateGenre;
using WebApi.GenreOperations.DeleteGenreCommand;
using WebApi.GenreOperations.GetGenreDetail;
using WebApi.GenreOperations.GetGenres;
using WebApi.GenreOperations.GetGenresDetail;
using WebApi.GenreOperations.UpdateGenres;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;

        public GenreController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public IActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = id;

            //Validation
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.Validate(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = newGenre;

            //Validation
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.Validate(command);

            command.Handle();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = updateGenre;

            //Validation
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.Validate(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;

            //Validation
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.Validate(command);

            command.Handle();
            return Ok();
        }
    }
}
