using CarListAppMaui.Views;

namespace CarListAppMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(CarDetailsPage), typeof(CarDetailsPage)); 

	}
}
