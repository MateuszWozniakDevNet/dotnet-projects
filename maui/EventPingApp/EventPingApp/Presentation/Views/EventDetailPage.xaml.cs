using EventPingApp.Presentation.ViewModels;

namespace EventPingApp.Presentation.Views;

public partial class EventDetailPage : ContentPage
{
    private readonly EventDetailViewModel _viewModel;

    public EventDetailPage(EventDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
}