namespace EventPingApp.Application.Notification;

public interface INotificationTimeCalculator
{
    List<NotificationSchedule> Calculate(DateTime eventDate);
}
