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
using WebApi.GenreOperations.DeleteGenreCommand;
using Xunit;

namespace Tests.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            
            command.GenreId = 0;

            //act
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            DeleteGenreCommand command = new DeleteGenreCommand(null);

            command.GenreId = 1;

            //act
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
