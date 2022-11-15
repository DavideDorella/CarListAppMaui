using CarListAppMaui.ViewModels;

namespace CarListAppMaui;

public partial class MainPage : ContentPage
{
    private readonly CarlistViewModel carListViewModel;
    public MainPage(CarlistViewModel carlistViewModel)
	{
	    InitializeComponent();
		BindingContext = carlistViewModel;
        this.carListViewModel = carlistViewModel;
        
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await carListViewModel.GetCarList(); 
    }


}

