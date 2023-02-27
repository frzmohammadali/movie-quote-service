using MovieQuoteService.Application.Quotes.Queries;

namespace MovieQuoteService.WebUI.Quotes;

public class GetQuotes : AbstractEndpoint
{
    public override void Map(WebApplication app)
    {
        MapGet(app,
             async (ISender sender) => await sender.Send(new GetQuotesQuery()));
    }
}
