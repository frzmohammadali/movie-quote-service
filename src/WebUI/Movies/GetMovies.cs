using MovieQuoteService.Application.Movies.Queries;

namespace MovieQuoteService.WebUI.Movies;

public class GetMovies : AbstractEndpoint
{
    public override void Map(WebApplication app)
    {
        MapGet(app,
             async (ISender sender) => await sender.Send(new GetMoviesQuery()));
    }
}
