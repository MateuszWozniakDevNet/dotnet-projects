using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EventPingApp.Application.Navigation;
using EventPingApp.Application.UseCases.DeleteCalendarEvent;
using EventPingApp.Presentation.Models;
using EventPingApp.Presentation.Views;

namespace EventPingApp.Presentation.ViewModels;

public partial class EventItemViewModel(INavigationService navigationService, IDeleteCalendarEventUseCase deleteUseCase, Func<Task> reloadCallback, CalendarEventItem item) : ObservableObject
{
    private readonly INavigationService _navigationService = navigationService;
    private readonly IDeleteCalendarEventUseCase _deleteUseCase = deleteUseCase;
    private readonly Func<Task> _reloadCallback = reloadCallback;

    public int Id { get; } = item.Id;
    public string Name { get; } = item.Name;
    public string Description { get; } = item.Description;
    public string TimeFormatted => item.Time.ToString(@"hh\:mm");

    [RelayCommand]
    private async Task EditEventAsync() => await _navigationService.NavigateToAsync(nameof(EventDetailPage), new ShellNavigationQueryParameters { { "EventId", Id } });

    [RelayCommand]
    private async Task DeleteEventAsync()
    {
        bool confirm = await Shell.Current.DisplayAlertAsync("Delete event", $"Are you sure you want to delete '{item.Name}'?", "Yes", "Cancel");

        if (!confirm)
        {
            return;
        }

        await _deleteUseCase.ExecuteAsync(item.Id);
        await _reloadCallback();
    }
}
