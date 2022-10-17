using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AuthorOperations.GetAuthorDetail;
using WebApi.BookOperations.GetBookDetail;
using Xunit;

namespace Tests.Application.BookOperations.GetBook
{
    public class GetDetailBookQueryValidatorTests
    {
        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            GetBookDetailQuery query = new GetBookDetailQuery(null, null);
            query.BookId = 0;

            //act
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            GetBookDetailQuery query = new GetBookDetailQuery(null, null);
            query.BookId = 2;

            //act
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
