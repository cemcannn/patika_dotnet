using FluentValidation;

namespace WebApi.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).NotEmpty();
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}
