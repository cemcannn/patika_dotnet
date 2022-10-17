using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestSetup;
using WebApi.BookOperations.CreateBook;
using Xunit;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Tests.Application.BookOperations.CreateBook
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory] //Birden fazla değeri denemek istediğimizde
        [InlineData("Lord Of The Rings", 0,0,0)] //Bu inlineData'ların her biri bir test case'i ifade ediyor.
        [InlineData("Lord Of The Rings", 0,1,0)]
        [InlineData("Lord Of The Rings", 100,0,0)]
        [InlineData("", 0,0,1)]
        [InlineData("", 100,1,0)]
        [InlineData("", 0,1,1)]
        [InlineData("Lor", 100,1,0)]
        [InlineData("Lord", 100, 0,0)]
        [InlineData("Lord", 0, 1,0)]
        public void WhenInvalidInputsAreGıven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId = genreId,
                AuthorId = authorId
            };

            //act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        // Sadece PublicDate'in çalıştığı case
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date,
                GenreId = 1,
                AuthorId = 1
            };

            //act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var error = validator.Validate(command);

            //assert
            error.Errors.Count.Should().BeGreaterThan(0);
        }

        //Happy Path - Tüm Koşulların Valid Olduğu Durum
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date.AddYears(-2),
                GenreId = 1,
                AuthorId = 1
            };

            //act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var error = validator.Validate(command);

            //assert
            error.Errors.Count.Should().Be(0);
        }
    }
}
