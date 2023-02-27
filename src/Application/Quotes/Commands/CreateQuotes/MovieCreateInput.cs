namespace MovieQuoteService.Application.Quotes.Commands.CreateQuotes;

public class MovieCreateInput
{
    public string DisplayName { get; set; } = null!;
    public int YearOfPublish { get; set; }
}
