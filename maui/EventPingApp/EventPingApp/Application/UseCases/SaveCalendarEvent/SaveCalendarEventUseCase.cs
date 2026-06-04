using EventPingApp.Application.Notification;
using EventPingApp.Application.Repositories;
using EventPingApp.Domain.Entities;

namespace EventPingApp.Application.UseCases.SaveCalendarEvent;

public class SaveCalendarEventUseCase(ICalendarEventRepository repository, INotificationManager notificationManager) : ISaveCalendarEventUseCase
{
    private readonly ICalendarEventRepository _repository = repository;
    private readonly INotificationManager _notificationManager = notificationManager;

    public async Task ExecuteAsync(SaveCalendarEventCommand command)
    {
        CalendarEvent calendarEvent;

        if (command.Id == 0)
        {
            calendarEvent = new CalendarEvent(0, command.Name, command.Description, command.Date);
        }
        else
        {
            calendarEvent = await _repository.GetByIdAsync(command.Id) ?? throw new InvalidOperationException("Event not found");
            calendarEvent.Update(command.Name, command.Description, command.Date);

            await _notificationManager.CancelForEventAsync(calendarEvent.Id);
        }

        await _repository.SaveAsync(calendarEvent);

        await _notificationManager.ScheduleForEventAsync(calendarEvent.Id, calendarEvent.Name, calendarEvent.Description, calendarEvent.Date);
    }
}
