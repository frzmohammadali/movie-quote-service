using MovieQuoteService.Application.TodoLists.Commands.DeleteTodoList;

namespace MovieQuoteService.WebUI.TodoLists;

public class DeleteTodoList : AbstractEndpoint
{
    public override void Map(WebApplication app)
    {
        MapDelete(app, "{id}",
            async (ISender sender, int id) =>
            {
                await sender.Send(new DeleteTodoListCommand(id));
                return Results.NoContent();
            });
    }
}