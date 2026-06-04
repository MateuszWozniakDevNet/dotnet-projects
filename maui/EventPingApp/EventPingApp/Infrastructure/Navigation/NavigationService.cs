using EventPingApp.Application.Navigation;

namespace EventPingApp.Infrastructure.Navigation;

public class NavigationService : INavigationService
{
    private const string BackwardsNavigation = "..";

    public async Task NavigateToAsync(string route, ShellNavigationQueryParameters? parameters = null)
    {
        Task task = parameters is not null ? Shell.Current.GoToAsync(route, parameters) : Shell.Current.GoToAsync(route);
        await task;
    }

    public async Task GoBackAsync() => await Shell.Current.GoToAsync(BackwardsNavigation);
}
