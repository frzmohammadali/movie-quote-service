using MovieQuoteService.Application.Characters.Queries;

namespace MovieQuoteService.WebUI.Characters;

public class GetCharacters : AbstractEndpoint
{
    public override void Map(WebApplication app)
    {
        MapGet(app,
             async (ISender sender) => await sender.Send(new GetCharactersQuery()));
    }
}
