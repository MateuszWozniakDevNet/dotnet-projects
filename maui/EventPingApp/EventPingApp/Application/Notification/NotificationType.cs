namespace EventPingApp.Application.Notification;

public enum NotificationType 
    : byte
{
    ThirtyMinutesBefore = 1,
    OneHourBefore = 2,
    DayBeforeAt21 = 3,
    Now = 4
}
