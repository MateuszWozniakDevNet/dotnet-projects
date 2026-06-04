using EventPingApp.Application.Notification;
using EventPingApp.Application.Repositories;

namespace EventPingApp.Application.UseCases.DeleteCalendarEvent;

public class DeleteCalendarEventUseCase(ICalendarEventRepository repository, INotificationManager notificationManager) : IDeleteCalendarEventUseCase
{
    private readonly ICalendarEventRepository _repository = repository;
    private readonly INotificationManager _notificationManager = notificationManager;

    public async Task ExecuteAsync(int eventId)
    {
        await _repository.DeleteAsync(eventId);

        await _notificationManager.CancelForEventAsync(eventId);
    }
}