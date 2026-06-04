namespace EventPingApp.Application.UseCases.SaveCalendarEvent;

public class SaveCalendarEventCommand
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime Date { get; init; }
}