using EventPingApp.Application.Repositories;
using EventPingApp.Domain.Entities;
using EventPingApp.Infrastructure.Entities;
using EventPingApp.Infrastructure.Mappers;
using EventPingApp.Infrastructure.Persistence;
using SQLite;

namespace EventPingApp.Infrastructure.Repositories;

public class CalendarEventRepository(IDatabaseProvider databaseProvider) : ICalendarEventRepository
{
    private readonly SQLiteAsyncConnection _connection = databaseProvider.GetConnection();
    private bool _initialized;

    private async Task InitializeAsync()
    {
        if (_initialized)
        {
            return;
        }

        await _connection.CreateTableAsync<CalendarEventEntity>();
        _initialized = true;
    }

    public async Task<IReadOnlyList<CalendarEvent>> GetAllAsync()
    {
        await InitializeAsync();
        var entities = await _connection.Table<CalendarEventEntity>().ToListAsync();
        return entities.Select(CalendarEventMapper.ToDomain).ToList();
    }

    public async Task<CalendarEvent?> GetByIdAsync(int id)
    {
        await InitializeAsync();
        var entity = await _connection.Table<CalendarEventEntity>().FirstOrDefaultAsync(e => e.Id == id);
        return entity is null ? null : CalendarEventMapper.ToDomain(entity);
    }

    public async Task SaveAsync(CalendarEvent calendarEvent)
    {
        await InitializeAsync();
        var entity = CalendarEventMapper.ToEntity(calendarEvent);

        if (entity.Id == 0)
        {
            await _connection.InsertAsync(entity);
            calendarEvent.SetId(entity.Id);
        }
        else
        {
            await _connection.UpdateAsync(entity);
        }
    }

    public async Task DeleteAsync(int id)
    {
        await InitializeAsync();
        await _connection.DeleteAsync<CalendarEventEntity>(id);
    }

}
