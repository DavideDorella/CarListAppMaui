using CarListAppMaui.Services;
using CarListAppMaui.ViewModels;
using CarListAppMaui.Views;

namespace CarListAppMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "cars.db3");		
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<CarDatabaseService>(s,dbPath));

		builder.Services.AddTransient<CarApiServices>();

        
		builder.Services.AddSingleton<CarlistViewModel>();
        builder.Services.AddSingleton<LoadingPageViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddTransient<CarDetailsViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<LoadingPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddTransient<CarDetailsPage>(); 

        return builder.Build();
	}
}
