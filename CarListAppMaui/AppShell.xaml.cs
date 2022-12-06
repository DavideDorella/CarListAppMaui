using CarListAppMaui.Views;

namespace CarListAppMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(CarDetailsPage), typeof(CarDetailsPage));
        
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        //Routing.RegisterRoute(nameof(LogoutPage), typeof(LogoutPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage)); Routing.RegisterRoute(nameof(CarDetailsPage), typeof(CarDetailsPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        //Routing.RegisterRoute(nameof(LogoutPage), typeof(LogoutPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

    }
}
