using CarListAppMaui.ViewModels; 
namespace CarListAppMaui;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel )
	{
		InitializeComponent();
		BindingContext = loginViewModel;
	}
}