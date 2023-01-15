using EvidencaPridelkov.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EvidencaPridelkov.Service
{
    public static class MainService
    {
        private static UserMaui User { get; set; }
        private static readonly FirebaseClient firebase = new FirebaseClient("https://evidencapridelkov-default-rtdb.europe-west1.firebasedatabase.app/");


        public static async Task<UserMaui> GetUser(string UserId)
        {
            // user = await firebase.Child("User").OrderByKey().EqualTo(UserId).OnceSingleAsync<UserMaui>();
            //UserMaui check = await firebase.Child("users").Child(UserId).OnceSingleAsync<UserMaui>();
            //if(check == null)
            //{
            //    user = await CreateUser(UserId);

            //}
            User = await firebase.Child("users").Child(UserId).OnceSingleAsync<UserMaui>();
            return User;
        }

        public static async Task AddUser(UserMaui user)
        {
            await firebase.Child("users").Child(user.Id).PutAsync(user);
        }

        public static async Task<ObservableCollection<Product>> GetAllProducts()
        {
            var products = new ObservableCollection<Product>();
            var list = User.Products_list;
            foreach (var product in list)
            {
                if (product != null) products.Add(product);
            }
            User.Products_list = products;
            return products;
        }

        public static async Task<Product> GetProduct(int id)
        {
            return User.Products_list.FirstOrDefault(x => x.Id == id);
        }

        public static async Task AddProduct(Product product)
        {
            if (product != null)
            {
                User.Products_list.Add(product);
                await firebase.Child("users").Child(User.Id).Child("Products_list").Child(product.Id.ToString()).PutAsync(product);
            }
        }

        public static async Task UpdateProduct(Product product)
        {
            if (product != null)
            {
                Product test = User.Products_list.FirstOrDefault(x => x.Id == product.Id);
                if (test != null)
                {
                    test.Id = product.Id;
                    test.Name = product.Name;
                    test.Price = product.Price;
                    test.Unit = product.Unit;
                    test.Quantity = product.Quantity;
                    test.Sold_quantity = product.Sold_quantity;
                    test.Min_qt_limit = product.Min_qt_limit;

                    await firebase.Child("users").Child(User.Id).Child("Products_list").Child(test.Id.ToString()).PutAsync(test);
                }
            }
        }

        public static async Task DeleteProduct(int Id)
        {
            Product test = User.Products_list.FirstOrDefault(x => x.Id == Id);
            if (test != null)
            {
                await firebase.Child("users").Child(User.Id).Child("Products_list").Child(test.Id.ToString()).DeleteAsync();
                User.Products_list.Remove(test);
            }
        }

        public static Task<UserMaui> CreateUser(string id)
        {       
            return Task.FromResult(new UserMaui { Id = id });
        }

        public static Task<bool> IsValidDouble(string input)
        {
            string pattern = @"^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$";
            return Task.FromResult(Regex.IsMatch(input, pattern));
        }
    }
}
