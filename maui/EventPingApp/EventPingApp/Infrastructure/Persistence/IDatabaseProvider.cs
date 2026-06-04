using SQLite;

namespace EventPingApp.Infrastructure.Persistence;

public interface IDatabaseProvider
{
    SQLiteAsyncConnection GetConnection();
}
