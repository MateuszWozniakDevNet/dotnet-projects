using EventPingApp.Application.Repositories;
using EventPingApp.Domain.Entities;

namespace EventPingApp.Application.UseCases.GetAllCalendarEvents;

public class GetAllCalendarEventsUseCase(ICalendarEventRepository repository) : IGetAllCalendarEventsUseCase
{
    private readonly ICalendarEventRepository _repository = repository;

    public async Task<IReadOnlyList<CalendarEvent>> ExecuteAsync() => await _repository.GetAllAsync();
}
