using MovieQuoteService.Application.TodoLists.Queries.GetTodos;

namespace MovieQuoteService.WebUI.TodoLists;

public class GetTodoLists : AbstractEndpoint
{
    public override void Map(WebApplication app)
    {
        MapGet(app,
             async (ISender sender) => await sender.Send(new GetTodosQuery()));
    }
}
