using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.AuthorOperations.CreateAuthor;
using WebApi.AuthorOperations.DeleteAuthor;
using WebApi.AuthorOperations.GetAuthorDetail;
using WebApi.AuthorOperations.GetAuthors;
using WebApi.AuthorOperations.UpdateAuthor;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorController(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_mapper, _dbContext);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            AuthorViewDetailModel result;

            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_dbContext, _mapper);
            query.AuthorId = Id;

            //Validation
            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            validator.Validate(query);

            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_dbContext, _mapper);
            command.Model = newAuthor;

            //Validation
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.Validate(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int Id, [FromBody] UpdateAuthorModel updateModel)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_dbContext);

            command.Model = updateModel;
            command.AuthorId = Id;

            //Validation
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.Validate(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int Id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_dbContext);
            command.AuthorId = Id;

            //Validation
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.Validate(command);

            command.Handle();

            return Ok();

        }
    }
}
