namespace EventPingApp.Domain.Entities;

public class CalendarEvent
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime Date { get; private set; }

    public CalendarEvent(int id, string name, string description, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Event name cannot be empty");
        }

        Id = id;
        SetValues(name, description, date);
    }

    public void Update(string name, string description, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Event name cannot be empty");
        }

        SetValues(name, description, date);
    }

    public void SetId(int id)
    {
        if (Id != 0)
        {
            throw new InvalidOperationException("Id is already set");
        }

        Id = id;
    }

    private void SetValues(string name, string description, DateTime date)
    {
        Name = name.Trim();
        Description = description?.Trim() ?? "";
        Date = date;
    }
}