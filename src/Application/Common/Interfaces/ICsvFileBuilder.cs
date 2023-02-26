using MovieQuoteService.Application.TodoLists.Queries.ExportTodos;

namespace MovieQuoteService.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
