using CarListAppMaui.ViewModels;
namespace CarListAppMaui;

public partial class LoadingPage : ContentPage
{
	public LoadingPage( LoadingPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext =viewModel;

	}
}