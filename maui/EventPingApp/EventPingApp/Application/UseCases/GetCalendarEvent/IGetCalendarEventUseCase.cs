using EventPingApp.Domain.Entities;

namespace EventPingApp.Application.UseCases.GetCalendarEvent;

public interface IGetCalendarEventUseCase
{
    Task<CalendarEvent> ExecuteAsync(int id);
}
