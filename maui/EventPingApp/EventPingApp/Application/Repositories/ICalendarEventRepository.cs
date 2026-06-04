using EventPingApp.Domain.Entities;

namespace EventPingApp.Application.Repositories;

public interface ICalendarEventRepository
{
    Task<CalendarEvent?> GetByIdAsync(int id);
    Task<IReadOnlyList<CalendarEvent>> GetAllAsync();
    Task SaveAsync(CalendarEvent calendarEvent);
    Task DeleteAsync(int id);
}
