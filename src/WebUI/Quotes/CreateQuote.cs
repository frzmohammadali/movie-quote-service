using MovieQuoteService.Application.Quotes.Commands.CreateQuotes;

namespace MovieQuoteService.WebUI.Quotes;

public class CreateQuote : AbstractEndpoint
{
    public override void Map(WebApplication app)
    {
        MapPost(app,
            async (ISender sender, CreateQuoteCommand command) => await sender.Send(command));
    }
}
