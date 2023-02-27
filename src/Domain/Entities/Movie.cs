namespace MovieQuoteService.Domain.Entities;

public class Movie : BaseEntity
{
    public string DisplayName { get; set; } = default!;
    public int YearOfPublish { get; set; }

    public ICollection<Quote> Quotes { get; set; } = Enumerable.Empty<Quote>().ToList();
}