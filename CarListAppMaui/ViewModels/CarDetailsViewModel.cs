using CarListAppMaui.Models;
using CarListAppMaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarListAppMaui.ViewModels
{
    [QueryProperty(nameof(Id),nameof(Id))]
    public partial class CarDetailsViewModel:BaseViewModel,IQueryAttributable
    {
        private readonly CarApiServices carApiService;

        public CarDetailsViewModel(CarApiServices carApiService)
        {
            this.carApiService = carApiService;
        }
        NetworkAccess accessType =Connectivity.Current.NetworkAccess;

        [ObservableProperty]
        Car car;

        [ObservableProperty]
        int id;

        public void  ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query[nameof(Id)].ToString()));
        
            
            Car = App.CarDatabaseService.GetCar(Id);  // DD PLEASE COULD YOU CHECK MY MISTAKE 
        }

        public async Task GetCarData()
        {
            if (accessType== NetworkAccess.Internet)
            {
                car = await carApiService.GetCar(Id);
            }
            else
            {
                 car = App.CarDatabaseService.GetCar(Id); // DD PLEASE COULD YOU CHECK MY MISTAKE 
            }
        }
    }

}
