using FluentValidation;
using WebApi.GenreOperations.GetGenreDetail;

namespace WebApi.GenreOperations.GetGenresDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}
