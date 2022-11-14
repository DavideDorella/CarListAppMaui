using CarListAppMaui.ViewModels;
using JetBrains.Annotations;

namespace CarListAppMaui.Views;

public partial class CarDetailsPage : ContentPage
{
	private readonly CarDetailsViewModel carDetailsViewModel;

	public CarDetailsPage(CarDetailsViewModel carDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = carDetailsViewModel;
		this.carDetailsViewModel = carDetailsViewModel;

	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await carDetailsViewModel.GetCarData();
	}
	//protected override void OnNavigatedTo(NavigatedToEventArgs args)
	//{
	//	// do fanciness	
	//	base.OnNavigatedTo(args);
	//}

}