namespace EventPingApp.Application.Notification;

public interface INotificationIdProvider
{
    int GetId(int eventId, NotificationType type);
    IEnumerable<int> GetAllIds(int eventId);
}
