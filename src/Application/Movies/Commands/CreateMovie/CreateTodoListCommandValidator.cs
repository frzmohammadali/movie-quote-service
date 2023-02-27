using MovieQuoteService.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace MovieQuoteService.Application.Movies.Commands.CreateMovie;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateMovieCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.DisplayName)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(BeUniqueDisplayName);

        RuleFor(v => v.YearOfPublish)
            .InclusiveBetween(1970, 2050);
    }

    public async Task<bool> BeUniqueDisplayName(string displayName, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .AllAsync(l => l.DisplayName != displayName, cancellationToken);
    }
}
