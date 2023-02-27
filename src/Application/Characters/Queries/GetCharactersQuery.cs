using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieQuoteService.Application.Common.Interfaces;
using MovieQuoteService.Application.Common.Security;
using MovieQuoteService.Domain.Entities;

namespace MovieQuoteService.Application.Characters.Queries;

[Authorize]
public record GetCharactersQuery : IRequest<IReadOnlyList<Character>>;

public class GetCharactersQueryHandler : IRequestHandler<GetCharactersQuery, IReadOnlyList<Character>>
{
    private readonly IApplicationDbContext _context;

    public GetCharactersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Character>> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
    {
        return (await _context.Characters
            .OrderBy(o => o.DisplayName).AsNoTracking().ToListAsync(cancellationToken: cancellationToken)).AsReadOnly();
    }
}
