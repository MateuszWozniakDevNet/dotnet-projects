using Plugin.LocalNotification.Core.Models.AndroidOption;

namespace EventPingApp.Infrastructure.Constants;

public static class NotificationConstants
{
    public const AndroidPriority Priority = AndroidPriority.High;
    public const AndroidVisibilityType VisibilityType = AndroidVisibilityType.Public;
    public const AndroidScheduleMode ScheduleMode = AndroidScheduleMode.ExactAllowWhileIdle;
}
