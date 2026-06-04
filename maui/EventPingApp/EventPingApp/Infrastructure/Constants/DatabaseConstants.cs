using SQLite;

namespace EventPingApp.Infrastructure.Constants;

public static class DatabaseConstants
{
    public const string DatabaseFilename = "CalendarEvents.db3";
    public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
}
