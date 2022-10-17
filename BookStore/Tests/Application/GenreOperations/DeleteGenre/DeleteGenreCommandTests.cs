using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestSetup;
using WebApi.BookOperations.DeleteBook;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.GenreOperations.DeleteGenreCommand;
using Xunit;

namespace Tests.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGenreIdIsNotExistThatIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            DeleteGenreCommand command = new DeleteGenreCommand(_context);

            command.GenreId = 20;

            //act & assert
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı.");
        }

        [Fact]
        public void WhenValidInputIsGiven_Genre_ShouldBeDeleted()
        {
            //arrange
            DeleteGenreCommand command = new DeleteGenreCommand(_context);

            command.GenreId = 1;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == command.GenreId);
            genre.Should().BeNull();
        }
    }
}
