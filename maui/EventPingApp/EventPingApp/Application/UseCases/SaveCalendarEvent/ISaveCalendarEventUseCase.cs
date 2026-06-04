namespace EventPingApp.Application.UseCases.SaveCalendarEvent;

public interface ISaveCalendarEventUseCase
{
    Task ExecuteAsync(SaveCalendarEventCommand command);
}
