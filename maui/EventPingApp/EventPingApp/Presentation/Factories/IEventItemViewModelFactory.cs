using EventPingApp.Presentation.Models;
using EventPingApp.Presentation.ViewModels;

namespace EventPingApp.Presentation.Factories;

public interface IEventItemViewModelFactory
{
    EventItemViewModel Create(CalendarEventItem model, Func<Task> reloadCallback);
}
