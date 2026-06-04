using EventPingApp.Domain.Entities;

namespace EventPingApp.Application.UseCases.GetAllCalendarEvents;

public interface IGetAllCalendarEventsUseCase
{
    Task<IReadOnlyList<CalendarEvent>> ExecuteAsync();
}
