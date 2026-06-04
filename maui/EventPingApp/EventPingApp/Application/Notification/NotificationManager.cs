using Plugin.LocalNotification;

namespace EventPingApp.Application.Notification;

public class NotificationManager(INotificationTimeCalculator timeCalculator, INotificationIdProvider idProvider, INotificationService notificationService) : INotificationManager
{
    private readonly INotificationTimeCalculator _timeCalculator = timeCalculator;
    private readonly INotificationIdProvider _idProvider = idProvider;
    private readonly INotificationService _notificationService = notificationService;

    public async Task ScheduleForEventAsync(int eventId, string title, string description, DateTime eventDate)
    {
        var hasPermission = await CheckAndRequestNotificationPermissionAsync();
        if (!hasPermission)
        {
            return;
        }

        var schedules = _timeCalculator.Calculate(eventDate);

        foreach (var schedule in schedules.OrderBy(s => s.Time))
        {
            var id = _idProvider.GetId(eventId, schedule.Type);
            await _notificationService.ScheduleAsync(id, title, description, schedule.Time);
        }
    }

    public async Task CancelForEventAsync(int eventId)
    {
        foreach (var id in _idProvider.GetAllIds(eventId))
        {
            await _notificationService.CancelAsync(id);
        }
    }

    private async Task<bool> CheckAndRequestNotificationPermissionAsync()
    {
        var allowed = await LocalNotificationCenter.Current.AreNotificationsEnabled();
        if (allowed)
        {
            return true;
        }

        return await LocalNotificationCenter.Current.RequestNotificationPermission();
    }
}