using CarListAppMaui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json; // add
using System.Net.Http.Json; // add
using CarListAppMaui.ViewModels; // add

namespace CarListAppMaui.Services
{
        public class CarApiServices
    {
        private readonly HttpClient _httpClient;
        public string StatusMessage;
         //public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:8099" : "http://localhost:8099";
                
        private static readonly string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android 
            ? "http://10.0.2.2:5041" 
            : "http://localhost:5041";

           public CarApiServices()
        { 
            _httpClient=new()  {  BaseAddress= new Uri(BaseAddress)};
        }
        public async Task <List<Car>>GetCars()
        {
            try
            {
                var respone = await _httpClient.GetStringAsync("/cars");
                return JsonConvert.DeserializeObject<List<Car>>(respone);
                
            }
            catch (Exception ex)
            {
                StatusMessage = $"Errore: {ex.Message}";
            }

            return null;
        }
        public async Task<Car> GetCar(int id)
        {
            try
            {
                var respone = await _httpClient.GetStringAsync("/cars/" +id);
                return JsonConvert.DeserializeObject<Car>(respone);

            }
            catch (Exception)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null; 
        }
        public async Task AddCar(Car car)
        {
            try
            {
                var respone = await _httpClient.PostAsJsonAsync("/cars/" ,car);
                respone.EnsureSuccessStatusCode();
                StatusMessage = "Insert Successful";                
            }
            catch (Exception ex)
            {
                StatusMessage = $"Errore: {ex.Message}";
            }
        }
        public async Task DeleteCar(int id)
        {
            try
            {
                var respone = await _httpClient.DeleteAsync("/cars/"+id);
                respone.EnsureSuccessStatusCode();
                StatusMessage = "Delete Successful";
            }
            catch (Exception)
            {
                StatusMessage = "Failed to delete data.";
            }
        }
        public async Task UpdateCar(int id, Car car)

        {
            try
            {
                
                var response = await _httpClient.PutAsJsonAsync("/cars/" + id, car);
                response.EnsureSuccessStatusCode();
                StatusMessage = "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Errore: {ex.Message}";
            }
        }

    }
}
