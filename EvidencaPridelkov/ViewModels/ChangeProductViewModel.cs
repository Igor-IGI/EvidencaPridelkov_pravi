using EvidencaPridelkov.Models;
using EvidencaPridelkov.Service;
using EvidencaPridelkov.View.ProductView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencaPridelkov.ViewModels
{
    class ChangeProductViewModel
    {

        private INavigation _navigation;
        private ChangeProductView productView;
        public Product Product { get; set; }
        public Command MinusQtBtn { get; }
        public Command AddQtBtn { get; }
        public Command MinusSoldQtBtn { get; }
        public Command AddSoldQtBtn { get; }
        public Command SaveChangetProductBtn { get; }
        public ChangeProductViewModel(INavigation nav, ChangeProductView view = null)
        {
            _navigation = nav;
            productView = view;
            Product = view.Product ?? null;
            MinusQtBtn = new Command(MinusQtBtnClick);
            AddQtBtn = new Command(AddQtBtnClick);
            MinusSoldQtBtn = new Command(MinusSoldQtBtnClick);
            AddSoldQtBtn = new Command(AddSoldQtBtnClick);
            SaveChangetProductBtn = new Command(SaveChangetProductClick);
        }

        private async void SaveChangetProductClick(object obj)
        {
            await MainService.UpdateProduct(Product);
            await _navigation.PopAsync();
        }

        private async void AddQtBtnClick(object obj)
        {
            Entry nameAddQt = productView.FindByName<Entry>("inpQuantity");
            Entry lblQuantity = productView.FindByName<Entry>("lblQuantity");

            if (await MainService.IsValidDouble(nameAddQt.Text))
                Product.Quantity += double.Parse(nameAddQt.Text);

            else
                await productView.DisplayAlert("Opozorilo", "Za zalogo lahko vnesee samo decimalno število.", "Zapri");
        }

        public async void MinusQtBtnClick(object obj)
        {
            Entry nameQt = productView.FindByName<Entry>("inpQuantity");
            Entry lblQuantity = productView.FindByName<Entry>("lblQuantity");

            if (await MainService.IsValidDouble(nameQt.Text))
            {
                if (double.Parse(nameQt.Text) <= Product.Quantity)
                    Product.Quantity -= double.Parse(nameQt.Text);
                else
                    await productView.DisplayAlert("Opozorilo", "Odštevete lahko samo isto ali manjšo vrednost kot je zaloga", "Zapri");
            }
            else
                await productView.DisplayAlert("Opozorilo", "Za zalogo lahko vnesee samo decimalno število.", "Zapri");
        }

        private async void AddSoldQtBtnClick(object obj)
        {
            Entry nameAddQt = productView.FindByName<Entry>("inpQuantity");
            Entry lblSoldQuantity = productView.FindByName<Entry>("lblSoldQuantity");

            if (await MainService.IsValidDouble(nameAddQt.Text))
                Product.Sold_quantity += double.Parse(nameAddQt.Text);
            else
                await productView.DisplayAlert("Opozorilo", "Za zalogo lahko vnesee samo decimalno število.", "Zapri");
        }


        public async void MinusSoldQtBtnClick(object obj)
        {
            Entry nameSoldQt = productView.FindByName<Entry>("inpSoldQuantity");
            Entry lblSoldQuantity = productView.FindByName<Entry>("lblSoldQuantity");

            if (await MainService.IsValidDouble(nameSoldQt.Text))
            {
                if (double.Parse(nameSoldQt.Text) <= Product.Quantity)
                    Product.Sold_quantity -= double.Parse(nameSoldQt.Text);
                else
                    await productView.DisplayAlert("Opozorilo", "Odštevete lahko samo isto ali manjšo vrednost kot je prodaja", "Zapri");
            }
            else
                await productView.DisplayAlert("Opozorilo", "Za zalogo lahko vnesee samo decimalno število.", "Zapri");
        }
    }
}
