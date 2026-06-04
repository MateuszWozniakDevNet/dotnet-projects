using EventPingApp.Domain.Entities;
using EventPingApp.Infrastructure.Entities;

namespace EventPingApp.Infrastructure.Mappers;

public static class CalendarEventMapper
{
    public static CalendarEvent ToDomain(CalendarEventEntity entity) => new(entity.Id, entity.Name, entity.Description, entity.Date);
    public static CalendarEventEntity ToEntity(CalendarEvent domain) => new() { Id = domain.Id, Name = domain.Name, Description = domain.Description, Date = domain.Date };
}
