

using CarListAppMaui.Models;

using CarListAppMaui.Services;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using CoreData;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarListAppMaui.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
      
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;
        //private CarApiService carApiService;

        [RelayCommand]
        async Task Login()
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                // await DisplayLoginMessage("Invalid Login Attempt");
                await DisplayLoginError();
               // await Shell.Current.DisplayAlert("Invalid Attempt ", "Invalid User or Password", "OK");
               

            }
            else
            {
                var loginSuccessful = true;
                if (loginSuccessful) 
                { 
                    // dispaly welcome message 
                    
                    // build a menu on the fly ... based on the user role

                    // navigate to app's main page

                
                }
                await DisplayLoginError();

                // Call API to attempt a login
                //var loginModel = new LoginModel(username, password);

                //var response = await carApiService.Login(loginModel);

                //// display message
                //await DisplayLoginMessage(carApiService.StatusMessage);

                //if (!string.IsNullOrEmpty(response.Token))
                //{
                //    // Store token in secure storage 
                //    await SecureStorage.SetAsync("Token", response.Token);

                //    // build a menu on the fly...based on the user role
                //    var jsonToken = new JwtSecurityTokenHandler().ReadToken(response.Token) as JwtSecurityToken;

                //    var role = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(ClaimTypes.Role))?.Value;

                //    App.UserInfo = new UserInfo()
                //    {
                //        Username = Username,
                //        Role = role
                //    };


                //    // navigate to app's main page
                //    MenuBuilder.BuildMenu();
                //    await Shell.Current.GoToAsync($"{nameof(MainPage)}");

                //}
                //else
                //{
                //    await DisplayLoginMessage("Invalid Login Attempt");
                //}
            }
        }

        async Task DisplayLoginError()
        {
            await Shell.Current.DisplayAlert("Invalid Attempt ", "Invalid User or Password", "OK");
            password = string.Empty;
        }
    }
}
