using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieQuoteService.Application.Common.Interfaces;
using MovieQuoteService.Application.Common.Security;
using MovieQuoteService.Domain.Entities;

namespace MovieQuoteService.Application.Movies.Queries;

[Authorize]
public record GetMoviesQuery : IRequest<IReadOnlyList<Movie>>;

public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IReadOnlyList<Movie>>
{
    private readonly IApplicationDbContext _context;

    public GetMoviesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        return (await _context.Movies
            .Include(i => i.Quotes)
            .OrderBy(o => o.DisplayName).AsNoTracking().ToListAsync(cancellationToken: cancellationToken)).AsReadOnly();
    }
}
