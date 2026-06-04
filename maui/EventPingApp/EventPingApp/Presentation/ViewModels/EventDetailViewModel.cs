using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventPingApp.Application.Navigation;
using EventPingApp.Application.UseCases.GetCalendarEvent;
using EventPingApp.Application.UseCases.SaveCalendarEvent;
using EventPingApp.Application.Validation;
using Plugin.ValidationRules;
using Plugin.ValidationRules.Extensions;

namespace EventPingApp.Presentation.ViewModels;

[QueryProperty(nameof(EventId), "EventId")]
public partial class EventDetailViewModel(INavigationService navigationService, ISaveCalendarEventUseCase saveUseCase, IGetCalendarEventUseCase getUseCase) : ObservableObject
{
    private readonly INavigationService _navigationService = navigationService;
    private readonly ISaveCalendarEventUseCase _saveUseCase = saveUseCase;
    private readonly IGetCalendarEventUseCase _getUseCase = getUseCase;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(SaveButtonText))]
    private int _eventId;

    [ObservableProperty]
    private DateTime _date = DateTime.Today;

    [ObservableProperty]
    private TimeSpan _time = TimeSpan.Zero;

    public Validatable<string> Name { get; } = Validator.Build<string>().WithRule(new IsNotNullOrEmptyRule(), "A Name is required.");
    public Validatable<string> Description { get; } = Validator.Build<string>().WithRule(new IsNotNullOrEmptyRule(), "A Description is required.");   
    public string SaveButtonText => EventId == 0 ? "💾 Save event" : "💾 Save changes";

    partial void OnEventIdChanged(int value) => _ = HandleEventIdChangedAsync(value);

    [RelayCommand]
    private async Task SaveEventAsync()
    {
        bool isValidName = Name.Validate(), isValidDescription = Description.Validate();
        if (!isValidName || !isValidDescription)
        {
            return;
        }

        await _saveUseCase.ExecuteAsync(new SaveCalendarEventCommand { Id = EventId, Name = Name.Value, Description = Description.Value, Date = Date.Date + Time });
        await _navigationService.GoBackAsync();
    }

    private async Task LoadAsync(int eventId)
    {
        var calendarEvent = await _getUseCase.ExecuteAsync(eventId);

        if (calendarEvent is null)
        {
            return;
        }

        Name.Value = calendarEvent.Name;
        Description.Value = calendarEvent.Description;
        Date = calendarEvent.Date.Date;
        Time = calendarEvent.Date.TimeOfDay;
    }

    private async Task HandleEventIdChangedAsync(int value) => await LoadAsync(value);
}
