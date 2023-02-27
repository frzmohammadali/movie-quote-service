using MovieQuoteService.Application.Movies.Commands.CreateMovie;

namespace MovieQuoteService.WebUI.Movies;

public class CreateMovie : AbstractEndpoint
{
    public override void Map(WebApplication app)
    {
        MapPost(app,
            async (ISender sender, CreateMovieCommand command) => await sender.Send(command));
    }
}
