using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestSetup;
using WebApi.BookOperations.GetBookDetail;
using WebApi.DBOperations;
using WebApi.GenreOperations.GetGenreDetail;
using Xunit;

namespace Tests.Application.GenreOperations.GetGenre
{
    public class GetDetailGenreQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDetailGenreQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGenreIdIsNotExistThatIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = 0;

            //act & assert
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı.");
        }

        [Fact]
        public void WhenValidInputIsGiven_Genre_ShouldBeDeleted()
        {
            //arrange
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = 2;

            //act
            FluentActions.Invoking(() => query.Handle()).Invoke();

            //assert
            var genre = _context.Genres.SingleOrDefault(book => book.Id == query.GenreId);
            genre.Should().NotBeNull();
        }
    }
}
