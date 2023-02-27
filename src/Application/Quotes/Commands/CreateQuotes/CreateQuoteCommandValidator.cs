using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieQuoteService.Application.Common.Interfaces;

namespace MovieQuoteService.Application.Quotes.Commands.CreateQuotes;

public class CreateQuoteCommandValidator : AbstractValidator<CreateQuoteCommand>
{
    public CreateQuoteCommandValidator()
    {
        RuleFor(v => v.Text)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(r => r.CharacterCreateInput)
            .NotNull()
            .When(w => w.CharacterId is null);

        RuleFor(r => r.MovieCreateInput)
            .NotEmpty()
            .When(w => w.MovieId is null);

        RuleFor(r => r.CharacterId)
            .NotNull()
            .When(w => w.CharacterCreateInput is null);

        RuleFor(r => r.MovieId)
            .NotNull()
            .When(w => w.MovieCreateInput is null);
    }
    
}
