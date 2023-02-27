using MovieQuoteService.Application.Common.Interfaces;
using MovieQuoteService.Domain.Entities;
using MediatR;

namespace MovieQuoteService.Application.Movies.Commands.CreateMovie;

public record CreateMovieCommand : IRequest<int>
{
    public string DisplayName { get; init; } = null!;
    public int YearOfPublish { get; init; }
}

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateMovieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        Movie entity = new Movie
        {
            DisplayName = request.DisplayName,
            YearOfPublish = request.YearOfPublish
        };

        _context.Movies.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
