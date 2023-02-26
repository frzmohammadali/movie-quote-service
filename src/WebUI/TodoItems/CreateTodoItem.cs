using MovieQuoteService.Application.TodoItems.Commands.CreateTodoItem;

namespace MovieQuoteService.WebUI.TodoItems;

public class CreateTodoItem : AbstractEndpoint
{
    public override void Map(WebApplication app)
    {
        MapPost(app,
            async (ISender sender, CreateTodoItemCommand command) => await sender.Send(command));
    }
}
