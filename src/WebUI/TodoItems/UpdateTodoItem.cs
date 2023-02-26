using MovieQuoteService.Application.TodoItems.Commands.UpdateTodoItem;

namespace MovieQuoteService.WebUI.TodoItems;

public class UpdateTodoItem : AbstractEndpoint
{
    public override void Map(WebApplication app)
    {
        MapPut(app, "{id}",
            async (ISender sender, int id, UpdateTodoItemCommand command) =>
            {
                if (id != command.Id) return Results.BadRequest();

                await sender.Send(command);

                return Results.NoContent();
            });
    }
}
