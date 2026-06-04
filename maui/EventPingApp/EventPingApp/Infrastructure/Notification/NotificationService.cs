using EventPingApp.Infrastructure.Constants;
using Plugin.LocalNotification;
using Plugin.LocalNotification.Core.Models;
using Plugin.LocalNotification.Core.Models.AndroidOption;
using INotificationService = EventPingApp.Application.Notification.INotificationService;

namespace EventPingApp.Infrastructure.Notification;

public class NotificationService : INotificationService
{
    public async Task ScheduleAsync(int eventId, string title, string description, DateTime date)
    {
        #if WINDOWS
            return;
        #else
            if (date <= DateTime.Now)
            {
                return;
            }

            var request = new NotificationRequest
            {
                NotificationId = eventId,
                Title = title,
                Description = description,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = date.ToLocalTime(),
                    Android = new AndroidScheduleOptions
                    {
                        ScheduleMode = NotificationConstants.ScheduleMode
                    }
                },
                Android = new AndroidOptions
                {
                    Priority = NotificationConstants.Priority,
                    VisibilityType = NotificationConstants.VisibilityType
                }
            };
        
            await LocalNotificationCenter.Current.Show(request);
        #endif
    }

    public Task CancelAsync(int eventId)
    {
        #if WINDOWS
            return Task.CompletedTask;
        #else
            LocalNotificationCenter.Current.Cancel(eventId);
            return Task.CompletedTask;
        #endif
    }
}
