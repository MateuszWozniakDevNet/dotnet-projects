using EventPingApp.Presentation.Views;

namespace EventPingApp.Presentation.Navigation;

public static class Routes
{
    public static void Register()
    {
        Routing.RegisterRoute(nameof(EventDetailPage), typeof(EventDetailPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}
