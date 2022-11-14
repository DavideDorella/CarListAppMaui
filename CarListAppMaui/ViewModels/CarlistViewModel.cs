using CarListAppMaui.Models;
using CarListAppMaui.Services;
using CarListAppMaui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using System.ComponentModel;


namespace CarListAppMaui.ViewModels
{
    public partial class CarlistViewModel : BaseViewModel
    {
        //private readonly CarDatabaseService carDataBaseService;
        private readonly CarApiServices carApiService;
        NetworkAccess accessType =Connectivity.Current.NetworkAccess;
        string message =string.Empty;


        const string editButtonText = "Update Car";
        const string createButtonText = "Add Car";

        public ObservableCollection<Car> Cars { get; private set; } = new();


        //public ObservableCollection<Car> Cars { get; private set; }

        //public CarlistViewModel(CarDatabaseService carService)
        public CarlistViewModel(CarApiServices carApiService)
        {
            Title = "Car List";
            AddEditButtonText =createButtonText;
            //GetCarList().Wait();
            this.carApiService = carApiService;
        }
        [ObservableProperty]
        bool isRefreshing;
        [ObservableProperty]
        string make;
        [ObservableProperty]
        string model;
        [ObservableProperty]
        string vin;
        [ObservableProperty]
        string addEditButtonText;
        [ObservableProperty]
        int carId;


        [RelayCommand]
        async Task GetCarList()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Cars.Any()) Cars.Clear();

                //var cars = carService.GetCars();
                var cars =new List<Car>();
                if (accessType ==NetworkAccess.Internet)
                {
                    cars = await carApiService.GetCars();
                }
                else
                {
                    //cars = App.CarDatabaseService.GetCars(); // DD PLEASE COULD YOU CHECK MY MISTAKE 
                    
                }
                

                foreach (var car in cars) Cars.Add(car);

                //string filename = "carlist.json";
                //var serializedList = JsonSerializer.Serialize(cars);
                //File.WriteAllText(filename, serializedList);

                //var rawText = File.ReadAllText(filename);
                //var carsFromText = JsonSerializer.Deserialize<List<Car>>(rawText);

                //string path = FileSystem.AppDataDirectory;

                //string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to get cars: {ex.Message}");

                //await Shell.Current.DisplayAlert("Error", "Failed to retrive list of cars.", "Ok");
                await ShowAlert("Failed to retrive list of cars.");

            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }
        [RelayCommand]
        async Task GetCarDetails(int id)
        {
            if (id == 0l) return;
            await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?Id={id}", true);

        }

        [RelayCommand]
        async Task AddCar()
        {
            if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok");
                return;
            }
            var car = new Car
            {
                Make = Make,
                Model = Model,
                Vin = Vin
            };

            App.CarService.AddCar(car);
            await Shell.Current.DisplayAlert("Info", App.CarService.StatusMessage, "Ok");
            await GetCarList();

        }

        [RelayCommand]
        async Task SaveCar()
        {
            if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
            {
                await ShowAlert("Please insert valid data"); 
                return;
            }
            var car = new Car
            {
                Make = Make,
                Model = Model,
                Vin = Vin
            };

            if (CarId != 0)
            {
                if (accessType == NetworkAccess.Internet)
                {
                    await carApiService.UpdateCar(CarId, car);
                    message = carApiService.StatusMessage;
                }
                else
                {

                    //App.CarDatabaseService.UpdateCar(car); // DD PLEASE COULD YOU CHECK MY MISTAKE 

                    //message = App.CarDatabaseService.StatusMessage;// DD PLEASE COULD YOU CHECK MY MISTAKE 

                }
            }
            else
            {
                if (accessType == NetworkAccess.Internet)
                {
                    await carApiService.AddCar(car);
                    message = carApiService.StatusMessage;
                }
                else
                {

                    //App.CarDatabaseService.AddCar(car); // DD PLEASE COULD YOU CHECK MY MISTAKE 
                    //message = App.CarDatabaseService.StatusMessage; // DD PLEASE COULD YOU CHECK MY MISTAKE 
                }
            }

            await ShowAlert(message);
            await GetCarList();
            await ClearForm();

        }


        [RelayCommand]
        async Task DeleteCar(int id)
        {

            if (id == 0)
            {
                await ShowAlert ("Please try again");
                return;
            }
            if (accessType== NetworkAccess.Internet)
            {
                await carApiService.DeleteCar(id);
                message = carApiService.StatusMessage;
            }
            else
            {
                //App.CarDatabaseService.DeleteCar(id);  // DD PLEASE COULD YOU CHECK MY MISTAKE 
                //message = App.CarDatabaseService.StatusMessage;  // DD PLEASE COULD YOU CHECK MY MISTAKE 

            }
            await ShowAlert("Record Removed Successfully");
            await GetCarList();

            //var result = App.CarService.DeleteCar(id);
            //if (result == 0) await Shell.Current.DisplayAlert("Failed", "Please insert valid data", "Ok");
            //else
            //{
            //    await Shell.Current.DisplayAlert("Deletion Successful", "Record Removed Successfully", "Ok");
            //    await GetCarList();

            //}
        }

        [RelayCommand]

        async Task UpdateCar(Car car)
        {
            AddEditButtonText = editButtonText;
            return; 
            //try
            //{
                
                //dd Init();

                // dd if (car == null)
                // dd   throw new Exception("Invalid Car Record");
                // dd result = conn.Update(car);
                //dd StatusMessage = result == 0 ? "Update Failed" : "Update Successful";
            //}
            //catch (Exception ex)
            //{
                //dd StatusMessage = "Failed to Update data.";
           // }

        }

        [RelayCommand]
        async Task SetEditMode(int id)
        {
            AddEditButtonText = editButtonText;
            CarId = id;
            var car = App.CarService.GetCar(id);
            Make = car.Make;
            Model = car.Model;
            Vin = car.Vin;
        }
        [RelayCommand]
        async Task ClearForm()
        {
            AddEditButtonText = createButtonText;
            CarId = 0;
            Make = String.Empty;
            Model = String.Empty;
            Vin = String.Empty;

        }
        private async Task ShowAlert(string message)
        {
            await Shell.Current.DisplayAlert("info", message, "Ok");
        }
    }
}
