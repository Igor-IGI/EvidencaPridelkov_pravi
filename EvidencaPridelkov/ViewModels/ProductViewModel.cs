using CommunityToolkit.Mvvm.ComponentModel;
using EvidencaPridelkov.Models;
using EvidencaPridelkov.Service;
using EvidencaPridelkov.View.ProductView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EvidencaPridelkov.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged //: ObservableObject 
    {
        private INavigation _navigation;

        private ProductListView listView;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> Products { get; set; }

        public Command AddUpdateProductBtn { get; }
        public Command GetProducts { get; }
        public Command AddChangeProduct { get; }

        public Command<Product> ItemTappedCommand { get; }
        public Command<Product> ItemSwipedCommand { get; }

        public ProductViewModel(INavigation nav, ProductListView view = null)
        {
            _navigation = nav;
            listView = view;
            AddUpdateProductBtn = new Command(AddUpdateProductBtnTapped);
            ItemTappedCommand = new Command<Product>(DisplayAction);
            ItemSwipedCommand = new Command<Product>(SwipedProduct);
        }

        private async void AddUpdateProductBtnTapped(object obj)
        {
            await _navigation.PushAsync(new AddUpdateProductView(null, this));
        }

        public async Task GetProductList()
        {
            Products = await MainService.GetAllProducts();
            OnPropertyChanged(nameof(Products));
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        //[ICommand]
        public async void DisplayAction(Product product) // Kako dobi v parametru produkt?
        {
            var response = await listView.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                await _navigation.PushAsync(new AddUpdateProductView(product, this));
            }
            else if (response == "Delete")
            {
                await MainService.DeleteProduct(product.Id);
            }
        }

        public async void SwipedProduct(Product product)
        {
            await _navigation.PushAsync(new ChangeProductView(product));
        }


    }
}
