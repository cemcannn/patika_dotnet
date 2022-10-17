using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.AuthorOperations.GetAuthorDetail;
using WebApi.BookOperations.GetBookDetail;
using WebApi.GenreOperations.GetGenreDetail;
using WebApi.GenreOperations.GetGenresDetail;
using Xunit;

namespace Tests.Application.GenreOperations.GetGenre
{
    public class GetDetailGenreQueryValidatorTests
    {
        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            GetGenreDetailQuery query = new GetGenreDetailQuery(null, null);
            query.GenreId = 0;

            //act
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            GetGenreDetailQuery query = new GetGenreDetailQuery(null, null);
            query.GenreId = 2;

            //act
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var result = validator.Validate(query);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
