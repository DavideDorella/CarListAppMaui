using CarListAppMaui.Services;	
namespace CarListAppMaui;

public partial class App : Application
{
	public static CarDatabaseService CarService { get; private  set; }

	public App(CarDatabaseService carDataBaseService)
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
