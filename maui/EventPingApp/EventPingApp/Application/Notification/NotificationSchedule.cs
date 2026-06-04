namespace EventPingApp.Application.Notification;

public class NotificationSchedule(NotificationType type, DateTime time)
{
    public NotificationType Type { get; } = type;
    public DateTime Time { get; } = time;
}
