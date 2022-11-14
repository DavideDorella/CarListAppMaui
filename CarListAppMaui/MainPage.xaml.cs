using CarListAppMaui.ViewModels;

namespace CarListAppMaui;

public partial class MainPage : ContentPage
{
	
	public MainPage(CarlistViewModel carlistViewModel)
	{
	   //dd InitializeComponent();
		BindingContext = carlistViewModel;
		
		// esempio di salvataggio
		//Preferences.Set("saveDetails", true);
		//var detailsSaved = Preferences.Get("saveDetails", false);


	}

	
}

