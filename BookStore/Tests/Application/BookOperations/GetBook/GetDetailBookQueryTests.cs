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
using Xunit;

namespace Tests.Application.BookOperations.GetBook
{
    public class GetDetailBookQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDetailBookQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenBookIdIsNotExistThatIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = 10;

            //act & assert
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");
        }

        [Fact]
        public void WhenValidInputIsGiven_Book_ShouldBeDeleted()
        {
            //arrange
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = 2;

            //act
            FluentActions.Invoking(() => query.Handle()).Invoke();

            //assert
            var book = _context.Books.SingleOrDefault(book => book.Id == query.BookId);
            book.Should().NotBeNull();
        }
    }
}
