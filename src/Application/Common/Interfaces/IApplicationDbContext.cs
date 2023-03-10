using MovieQuoteService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MovieQuoteService.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Movie> Movies { get; }
    DbSet<Quote> Quotes { get; }
    DbSet<Character> Characters { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
