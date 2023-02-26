using MovieQuoteService.Application.Common.Interfaces;

namespace MovieQuoteService.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
