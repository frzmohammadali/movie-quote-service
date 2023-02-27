using MediatR;
using MovieQuoteService.Application.Common.Interfaces;
using MovieQuoteService.Domain.Entities;

namespace MovieQuoteService.Application.Quotes.Commands.CreateQuotes;

public record CreateQuoteCommand : IRequest<int>
{
    public string Text { get; set; } = null!;
    public int? MovieId { get; set; }
    public MovieCreateInput? MovieCreateInput { get; set; }
    public int? CharacterId { get; set; }
    public CharacterCreateInput? CharacterCreateInput { get; set; }

}

public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateQuoteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
    {
        var quote = new Quote
        {
            Text = request.Text,
            MovieId = request.MovieId ?? 0,
            CharacterId = request.CharacterId ?? 0
        };
        if (request.MovieId is null)
        {
            quote.Movie = new Movie {DisplayName = request.MovieCreateInput!.DisplayName, YearOfPublish = request.MovieCreateInput!.YearOfPublish};
        }
        if (request.CharacterId is null)
        {
            quote.Character = new Character { DisplayName = request.CharacterCreateInput!.DisplayName };
        }

        _context.Quotes.Add(quote);

        await _context.SaveChangesAsync(cancellationToken);

        return quote.Id;
    }
}
