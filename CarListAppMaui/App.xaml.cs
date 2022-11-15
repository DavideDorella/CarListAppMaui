using CarListAppMaui.Models; 
using CarListAppMaui.Services;	

namespace CarListAppMaui;

public partial class App : Application
{
		public static CarDatabaseService CarDatabaseService { get; private  set; }

	public App(CarDatabaseService carDataBaseService)
	{
		InitializeComponent();

		MainPage = new AppShell();
		CarDatabaseService = carDataBaseService;  //aggiunta tailor
    }
}
