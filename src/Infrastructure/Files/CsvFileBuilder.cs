using System.Globalization;
using MovieQuoteService.Application.Common.Interfaces;
using MovieQuoteService.Application.TodoLists.Queries.ExportTodos;
using MovieQuoteService.Infrastructure.Files.Maps;
using CsvHelper;

namespace MovieQuoteService.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
