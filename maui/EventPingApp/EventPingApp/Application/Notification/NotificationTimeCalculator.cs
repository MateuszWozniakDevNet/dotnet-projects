namespace EventPingApp.Application.Notification;

public class NotificationTimeCalculator : INotificationTimeCalculator
{
    public List<NotificationSchedule> Calculate(DateTime eventDate)
    {
        List<NotificationSchedule> results = [];
        DateTime now = DateTime.Now;

        if (eventDate <= now)
        {
            return results;
        }

        DateTime dayBeforeAt21 = eventDate.Date.AddDays(-1).AddHours(21), oneHourBefore = eventDate.AddHours(-1), thirtyMinBefore = eventDate.AddMinutes(-30);

        if (dayBeforeAt21 > now)
        {
            results.Add(new NotificationSchedule(NotificationType.DayBeforeAt21, dayBeforeAt21));
        }

        if (oneHourBefore > now)
        {
            results.Add(new NotificationSchedule(NotificationType.OneHourBefore, oneHourBefore));
        }

        if (thirtyMinBefore > now)
        {
            results.Add(new NotificationSchedule(NotificationType.ThirtyMinutesBefore, thirtyMinBefore));
        }

        results.Add(new NotificationSchedule(NotificationType.Now, eventDate.AddMinutes(2)));

        return results;
    }
}
