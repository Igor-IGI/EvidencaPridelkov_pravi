using EvidencaPridelkov.Models;
using EvidencaPridelkov.Service;
using EvidencaPridelkov.View;
using EvidencaPridelkov.View.ProductView;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencaPridelkov.ViewModels
{
    class LoginViewModel
    {
        public string webApiKey = "AIzaSyBcJO0vI86UwfyeTPu1yV1wdgltYC0txzo";

        private INavigation _navigation;

        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
        }

        private async void LoginBtnTappedAsync(object obj)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);

                var userId = auth.User.LocalId;
      
                UserMaui user = await MainService.GetUser(userId);
                if (user == null)
                {
                    user = await MainService.CreateUser(userId);
                    await MainService.AddUser(user);
                }

                user.Products_list ??= new ObservableCollection<Product>();  
                
                user.Orders_list ??= new ObservableCollection<Order>(); 
              
                user.Notes_list ??= new ObservableCollection<Notes>();


                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFirebaseToken", serializedContent);
                await _navigation.PushAsync(new LinkView());
            }
            catch (Exception ex)
            {
                string respons = "The email address or password is incorrect. Please retry.";
                string alert = "Alert";
                string okButton = "Ok";

                if (ex.Message.Contains("INVALID_EMAIL"))
                    await App.Current.MainPage.DisplayAlert(alert, respons, okButton);
                else if (ex.Message.Contains("EMAIL_NOT_FOUND"))
                    await App.Current.MainPage.DisplayAlert(alert, respons, okButton);
                else if (ex.Message.Contains("MISSING_PASSWORD"))
                    await App.Current.MainPage.DisplayAlert(alert, respons, okButton);
                else if (ex.Message.Contains("INVALID_PASSWORD"))
                    await App.Current.MainPage.DisplayAlert(alert, respons, okButton);
                //throw;
            }

        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await _navigation.PushAsync(new RegisterView());
        }
    }
}
