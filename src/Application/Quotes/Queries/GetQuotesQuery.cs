using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieQuoteService.Application.Common.Interfaces;
using MovieQuoteService.Application.Common.Security;
using MovieQuoteService.Domain.Entities;

namespace MovieQuoteService.Application.Quotes.Queries;

[Authorize]
public record GetQuotesQuery : IRequest<IReadOnlyList<Quote>>;

public class GetQuotesQueryHandler : IRequestHandler<GetQuotesQuery, IReadOnlyList<Quote>>
{
    private readonly IApplicationDbContext _context;

    public GetQuotesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Quote>> Handle(GetQuotesQuery request, CancellationToken cancellationToken)
    {
        return (await _context.Quotes
            .Include(i => i.Movie)
            .Include(i => i.Character)
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken)).AsReadOnly();
    }
}
