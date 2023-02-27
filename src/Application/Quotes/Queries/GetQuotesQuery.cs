using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieQuoteService.Application.Common.Interfaces;
using MovieQuoteService.Application.Common.Security;
using MovieQuoteService.Domain.Entities;

namespace MovieQuoteService.Application.Quotes.Queries;

[Authorize]
public record GetQuotesQuery : IRequest<IReadOnlyList<QuoteVm>>;

public class GetQuotesQueryHandler : IRequestHandler<GetQuotesQuery, IReadOnlyList<QuoteVm>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;

    public GetQuotesQueryHandler(IApplicationDbContext context, IMapper mapper, IIdentityService identityService)
    {
        _context = context;
        _mapper = mapper;
        _identityService = identityService;
    }

    public async Task<IReadOnlyList<QuoteVm>> Handle(GetQuotesQuery request, CancellationToken cancellationToken)
    {
        var quotes = await _context.Quotes
            .Include(i => i.Movie)
            .Include(i => i.Character)
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var quotesMapped = _mapper.Map<List<QuoteVm>>(quotes);

        foreach (var q in quotesMapped) 
            q.UserName = await _identityService.GetUserNameAsync(q.CreatedBy);

        return quotesMapped.AsReadOnly();
    }
}
