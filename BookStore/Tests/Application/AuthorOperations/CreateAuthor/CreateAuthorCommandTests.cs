using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestSetup;
using WebApi.AuthorOperations.CreateAuthor;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Tests.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistAuthorNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var author = new Author()
            {
                Name = "John Ronald Reuel",
                Lastname = "Tolkien",
                BirthDate = new DateTime(1982, 01, 03)
            };
            _context.Add(author);
            _context.SaveChanges();

            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            CreateAuthorModel model = new CreateAuthorModel() { Name = author.Name, Lastname = author.Lastname};

            //act & assert
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Zaten Mevcut!");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Author_ShoulBeCreated()
        {
            //arrange
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            CreateAuthorModel model = new CreateAuthorModel()
            {
                Name = "John Ronald Reuel",
                Lastname = "Tolkien",
                BirthDate = new DateTime(1982, 01, 03)
            };
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var author = _context.Authors.SingleOrDefault(author => author.Name == model.Name && author.Lastname == model.Lastname);
            author.Should().NotBeNull();
            author.BirthDate.Should().Be(model.BirthDate);
        }
    }
}
