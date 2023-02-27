using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieQuoteService.Application.Common.Interfaces;

namespace MovieQuoteService.Application.Quotes.Commands.CreateQuotes;

public class CreateQuoteCommandValidator : AbstractValidator<CreateQuoteCommand>
{
    public CreateQuoteCommandValidator(IValidator<MovieCreateInput> movieValidator)
    {
        RuleFor(v => v.Text)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(r => r.CharacterCreateInput)
            .NotNull()
            .When(w => w.CharacterId is null);

        RuleFor(r => r.MovieCreateInput)
            .NotNull()
            .SetValidator(movieValidator!)
            .When(w => w.MovieId is null);

        RuleFor(r => r.CharacterId)
            .NotNull()
            .When(w => w.CharacterCreateInput is null);

        RuleFor(r => r.MovieId)
            .NotNull()
            .When(w => w.MovieCreateInput is null);
    }
    
}


public class MovieCreateInputValidator : AbstractValidator<MovieCreateInput>
{
    public MovieCreateInputValidator()
    {
        RuleFor(v => v.DisplayName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(r => r.YearOfPublish)
            .InclusiveBetween(1970, 2050);
    }

}