using SQLite;

namespace EventPingApp.Infrastructure.Entities;

[Table("CalendarEvents")]
public class CalendarEventEntity
{
    [PrimaryKey, AutoIncrement, Column("Id")]
    public int Id { get; set; }
    [Column("Name")]
    public string Name { get; set; } = string.Empty;
    [Column("Description")]
    public string Description { get; set; } = string.Empty;
    [Column("Date")]
    public DateTime Date { get; set; }
}