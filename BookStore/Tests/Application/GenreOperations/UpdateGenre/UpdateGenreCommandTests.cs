using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestSetup;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using WebApi.GenreOperations.UpdateGenres;
using Xunit;

namespace Tests.Application.GenreOperations.UpdateGenre
{ 
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenBookIdIsNotExistThatIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 20;

            //act & assert
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı.");
        }

        [Fact]
        public void WhenValidInputIsGiven_Book_ShouldBeReturn()
        {
            //arrange
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            UpdateGenreModel model = new UpdateGenreModel()
            {
                Name = "Tv Series"
            };
            command.Model = model;
            command.GenreId = 2;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == command.GenreId);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(model.Name);
        }
    }
}
