﻿using FluentValidation;

namespace WebApi.GenreOperations.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
        }
    }
}
