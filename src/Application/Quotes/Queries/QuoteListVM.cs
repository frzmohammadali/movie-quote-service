using MovieQuoteService.Application.Common.Mappings;
using MovieQuoteService.Domain.Entities;

namespace MovieQuoteService.Application.Quotes.Queries;

public class QuoteVm : IMapFrom<Quote>
{
    public string Text { get; set; } = default!;
    public MovieVm Movie { get; set; } = default!;
    public CharacterVm Character { get; set; } = default!;
    public string CreatedBy { get; set; }
    public string UserName { get; set; } = default!;
    
}

public class MovieVm : IMapFrom<Movie>
{
    public string DisplayName { get; set; } = default!;
    public int YearOfPublish { get; set; }
}

public class CharacterVm : IMapFrom<Character>
{
    public string DisplayName { get; set; } = default!;
}
