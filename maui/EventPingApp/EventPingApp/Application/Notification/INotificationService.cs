namespace EventPingApp.Application.Notification;

public interface INotificationService
{
    Task ScheduleAsync(int eventId, string title, string description, DateTime date);
    Task CancelAsync(int eventId);
}
