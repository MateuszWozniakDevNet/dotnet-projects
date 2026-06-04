namespace EventPingApp.Application.Navigation;

public interface INavigationService
{
    Task NavigateToAsync(string route, ShellNavigationQueryParameters? parameters = null);
    Task GoBackAsync();
}
