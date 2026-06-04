namespace EventPingApp.Application.UseCases.DeleteCalendarEvent;

public interface IDeleteCalendarEventUseCase
{
    Task ExecuteAsync(int eventId);
}
