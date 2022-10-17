using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperations.UpdateBook;
using Xunit;

namespace Tests.Application.BookOperations.UpdateBook
{
    public class UpdateCommandBookValidatorTests
    {
        [Theory]
        [InlineData(1, 1, "Herland", 1, 100)]
        [InlineData(0, 1, "Herland", 1, 100)]
        [InlineData(1, 0, "Herland", 1, 100)]
        [InlineData(1, 1, "Her", 1, 100)]
        [InlineData(1, 1, "Herland", 0, 100)]
        [InlineData(1, 1, "Herland", 0, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int GenreId, int AuthorId, string Title, int BookId, int PageCount)
        {
            //arrange
            UpdateBookCommand command = new UpdateBookCommand(null);
            UpdateBookModel model = new UpdateBookModel()
            {
                Title = Title,
                GenreId = GenreId,
                AuthorId = AuthorId,
                PageCount = PageCount,
                PublishDate = DateTime.Now.AddYears(-2),
            };
            command.Model = model;
            command.BookId = BookId;

            //act
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInvalidPusblishDateIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            UpdateBookCommand command = new UpdateBookCommand(null);
            UpdateBookModel model = new UpdateBookModel()
            {
                Title = "Horror",
                GenreId = 1,
                AuthorId = 1,
                PageCount = 100,
                PublishDate = DateTime.Now,
            };
            command.Model = model;
            command.BookId = 1;

            //act
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            UpdateBookCommand command = new UpdateBookCommand(null);
            UpdateBookModel model = new UpdateBookModel()
            {
                Title = "Horror",
                GenreId = 1,
                AuthorId = 1,
                PageCount = 100,
                PublishDate = DateTime.Now.AddYears(-1),
            };
            command.Model = model;
            command.BookId = 1;

            //act
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
