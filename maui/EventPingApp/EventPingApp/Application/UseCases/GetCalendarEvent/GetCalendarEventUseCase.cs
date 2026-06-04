using EventPingApp.Application.Repositories;
using EventPingApp.Domain.Entities;

namespace EventPingApp.Application.UseCases.GetCalendarEvent;

public class GetCalendarEventUseCase(ICalendarEventRepository repository) : IGetCalendarEventUseCase
{
    private readonly ICalendarEventRepository _repository = repository;

    public async Task<CalendarEvent> ExecuteAsync(int id) => await _repository.GetByIdAsync(id) ?? throw new InvalidOperationException("Event not found");
}
