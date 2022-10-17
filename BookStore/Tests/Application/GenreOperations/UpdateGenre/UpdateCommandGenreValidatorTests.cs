using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperations.UpdateBook;
using WebApi.GenreOperations.UpdateGenres;
using Xunit;

namespace Tests.Application.GenreOperations.UpdateGenre
{
    public class UpdateCommandGenreValidatorTests
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            //arrange
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            UpdateGenreModel model = new UpdateGenreModel()
            {
                Name = "M"
            };
            command.Model = model;
            command.GenreId = 2;

            //act
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            UpdateGenreModel model = new UpdateGenreModel()
            {
                Name = "Mystery"
            };
            command.Model = model;
            command.GenreId = 1;

            //act
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
