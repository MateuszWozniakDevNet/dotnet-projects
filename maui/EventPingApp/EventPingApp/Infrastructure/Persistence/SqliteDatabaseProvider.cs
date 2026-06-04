using EventPingApp.Infrastructure.Constants;
using SQLite;

namespace EventPingApp.Infrastructure.Persistence;

public class SqliteDatabaseProvider : IDatabaseProvider
{
    private SQLiteAsyncConnection? _connection;

    public SQLiteAsyncConnection GetConnection()
    {
        if (_connection is not null)
        {
            return _connection;
        }

        var path = Path.Combine(FileSystem.AppDataDirectory, DatabaseConstants.DatabaseFilename);
        _connection = new SQLiteAsyncConnection(path, DatabaseConstants.Flags);
        return _connection;
    }
}
