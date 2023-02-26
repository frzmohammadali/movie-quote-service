using MovieQuoteService.Application.TodoItems.Commands.DeleteTodoItem;

namespace MovieQuoteService.WebUI.TodoItems;

public class DeleteTodoItem : AbstractEndpoint
{
    public override void Map(WebApplication app)
    {
        MapDelete(app, "{id}",
            async (ISender sender, int id) =>
            {
                await sender.Send(new DeleteTodoItemCommand(id));
                return Results.NoContent();
            });
    }
}
