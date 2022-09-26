using FluentValidation;
using System;

namespace WebApi.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4);
            RuleFor(command => command.Model.Lastname).MinimumLength(4);
            RuleFor(command => command.Model.BirthDate).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
