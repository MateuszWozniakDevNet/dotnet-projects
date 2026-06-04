namespace EventPingApp.Application.Notification;

public interface INotificationManager
{
    Task ScheduleForEventAsync(int eventId, string title, string description, DateTime eventDate);
    Task CancelForEventAsync(int eventId);
}
