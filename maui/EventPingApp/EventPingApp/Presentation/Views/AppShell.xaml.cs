using EventPingApp.Presentation.Navigation;

namespace EventPingApp.Presentation.Views;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routes.Register();
    }
}