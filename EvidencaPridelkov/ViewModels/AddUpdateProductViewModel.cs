using EvidencaPridelkov.Models;
using EvidencaPridelkov.Service;
using EvidencaPridelkov.View.ProductView;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EvidencaPridelkov.ViewModels
{
    class AddUpdateProductViewModel
    {
        private INavigation _navigation;
        private AddUpdateProductView productView;
        public Product Product { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Min_qt_limit { get; set; }

        public Command AddUpdateProductBtn { get; }

        public AddUpdateProductViewModel(INavigation nav, AddUpdateProductView view = null)
        {
            _navigation = nav;
            productView = view;
            Product = view.Product ?? null;
            AddUpdateProductBtn = new Command<Product>(AddChangeBtn);
        }

        public async void AddChangeBtn(Product product)
        {
            //Product = product;
            bool rightProduct = false;
            if (Product != null)
                rightProduct = await SetProduct();
            else
            {
                Product = new Product();
                rightProduct = await SetProduct();
            }

            if (productView.Title == "Dodajanje izdelka" && rightProduct)
            {
                var productsList = await MainService.GetAllProducts();
                if (productsList.Count > 0)
                    Product.Id = productsList.LastOrDefault().Id + 1;
                else
                    Product.Id = 0;
                await AddProduct(Product);
                // Update Products to render they on window ProductListView
                await productView._productViewModel.GetProductList();
                await _navigation.PopAsync();
            }
            else if (productView.Title == "Urejanje izdelka" && rightProduct)
            {
                await ChangeProduct(Product);
                await _navigation.PopAsync();
            }
        }

        // Function to validate inpudet values
        public async Task<bool> SetProduct()
        {
            Entry nameEntry = productView.FindByName<Entry>("inpName");
            Product.Name = nameEntry.Text;
            Entry nameUnit = productView.FindByName<Entry>("inpUnit");
            Product.Unit = nameUnit.Text;
            Entry nameMaxMinQt = productView.FindByName<Entry>("inpMinLimit");

            if (nameMaxMinQt.Text != null)
            {
                if (await MainService.IsValidDouble(nameMaxMinQt.Text))
                {
                    Product.Min_qt_limit = double.Parse(nameMaxMinQt.Text);
                    return true;
                }
                else
                {
                    await productView.DisplayAlert("Opozorilo", "Za minimalno zlogo obveščanja lahko uporabite samo število", "Zapri");
                    return false;
                }
            }
            else
            {
                await productView.DisplayAlert("Opozorilo", "Za minimalno zlogo obveščanja lahko uporabite samo število", "Zapri");
                return false;
            }
        }
        private async Task AddProduct(Product newProduct)
        {
            await MainService.AddProduct(newProduct);
            // Add Product to products of user in ObservableCollection
            //ProductViewModel.GetProductList();
        }
        private async Task ChangeProduct(Product updatedProduct)
        {
            await MainService.UpdateProduct(updatedProduct);
        }

    }
}
