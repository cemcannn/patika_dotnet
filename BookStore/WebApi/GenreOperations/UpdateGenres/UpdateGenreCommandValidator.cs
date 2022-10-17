using FluentValidation;

namespace WebApi.GenreOperations.UpdateGenres
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(2).When(x => x.Model.Name.Trim() != string.Empty);
        }
    }
}
