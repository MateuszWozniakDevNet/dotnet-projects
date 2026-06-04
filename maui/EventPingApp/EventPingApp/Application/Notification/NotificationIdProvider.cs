namespace EventPingApp.Application.Notification;

public class NotificationIdProvider : INotificationIdProvider
{
    public int GetId(int eventId, NotificationType type) => (eventId << 8) | (byte)type;

    public IEnumerable<int> GetAllIds(int eventId)
    {
        foreach (NotificationType type in Enum.GetValues<NotificationType>())
        {
            yield return GetId(eventId, type);
        }
    }
}