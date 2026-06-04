using EventPingApp.Application.Navigation;
using EventPingApp.Application.UseCases.DeleteCalendarEvent;
using EventPingApp.Presentation.Factories;
using EventPingApp.Presentation.Models;
using EventPingApp.Presentation.ViewModels;

namespace EventPingApp.Infrastructure.Factories;

public class EventItemViewModelFactory(INavigationService navigationService, IDeleteCalendarEventUseCase deleteUseCase) : IEventItemViewModelFactory
{
    private readonly INavigationService _navigationService = navigationService;
    private readonly IDeleteCalendarEventUseCase _deleteUseCase = deleteUseCase;

    public EventItemViewModel Create(CalendarEventItem item, Func<Task> reloadCallback) => new(_navigationService, _deleteUseCase, reloadCallback, item);
}
