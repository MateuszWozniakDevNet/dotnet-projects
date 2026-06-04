using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventPingApp.Application.Navigation;
using EventPingApp.Application.UseCases.GetAllCalendarEvents;
using EventPingApp.Presentation.Factories;
using EventPingApp.Presentation.Mappers;
using EventPingApp.Presentation.Views;
using Plugin.Maui.Calendar.Models;
using Plugin.ValidationRules.Extensions;

namespace EventPingApp.Presentation.ViewModels;

public partial class MainViewModel(INavigationService navigationService, IGetAllCalendarEventsUseCase getAllUseCase, IEventItemViewModelFactory eventFactory) : ObservableObject
{
    private readonly INavigationService _navigationService = navigationService;
    private readonly IGetAllCalendarEventsUseCase _getAllUseCase = getAllUseCase;
    private readonly IEventItemViewModelFactory _eventFactory = eventFactory;

    [ObservableProperty]
    private DateTime _selectedDate = DateTime.Today;

    [ObservableProperty]
    private EventCollection calendarEvents = [];

    [RelayCommand]
    private async Task LoadAsync()
    {
        var eventCollection = new EventCollection();
        var calendarEvents = await _getAllUseCase.ExecuteAsync();

        foreach (var calendarEvent in calendarEvents)
        {
            var date = calendarEvent.Date;
            if (!eventCollection.TryGetValue(date, out var dayEvents))
            {
                dayEvents = new List<EventItemViewModel>();
                eventCollection[date] = dayEvents;
            }

            var eventVM = _eventFactory.Create(CalendarEventItemMapper.ToItem(calendarEvent), LoadAsync);
            ((List<EventItemViewModel>)dayEvents).Add(eventVM);
        }

        CalendarEvents = eventCollection;
    }

    [RelayCommand]
    private async Task AddEventAsync() => await _navigationService.NavigateToAsync(nameof(EventDetailPage), new ShellNavigationQueryParameters { { "EventId", 0 } });
}
