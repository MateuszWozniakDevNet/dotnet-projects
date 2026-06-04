using EventPingApp.Domain.Entities;
using EventPingApp.Presentation.Models;

namespace EventPingApp.Presentation.Mappers;

public static class CalendarEventItemMapper
{
    public static CalendarEventItem ToItem(CalendarEvent e) => new()
    {
        Id = e.Id,
        Name = e.Name,
        Description = e.Description,
        Date = e.Date.Date,
        Time = e.Date.TimeOfDay,
    };
}
