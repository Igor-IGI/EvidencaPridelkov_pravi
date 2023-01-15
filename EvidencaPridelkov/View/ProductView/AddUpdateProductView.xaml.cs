using EvidencaPridelkov.Models;
using EvidencaPridelkov.Service;
using EvidencaPridelkov.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace EvidencaPridelkov.View.ProductView;

public partial class AddUpdateProductView : ContentPage, INotifyPropertyChanged
{
    public Product Product { get; private set; }
    private ObservableCollection<string> MyUnits { get; set; }
    public ProductViewModel _productViewModel { get; private set; }

    public AddUpdateProductView(Product prod = null, ProductViewModel productViewModel = null)
    {
        InitializeComponent();
        if (prod != null)
            Product = prod;
        if (productViewModel != null)
            _productViewModel = productViewModel;
        BindingContext = new AddUpdateProductViewModel(Navigation, this);
        AddUnits();
        SetPageTitle(prod == null);
    }

    private void SetPageTitle(bool addChange)
    {
        if (addChange)
        {
            this.Title = "Dodajanje izdelka";
            addChangeBtn.Text = "Dodaj";
        }
        else
        {
            this.Title = "Urejanje izdelka";
            addChangeBtn.Text = "Uredi";
        }
    }

    private void AddUnits()
    {
        MyUnits = new ObservableCollection<string>
        {
            "kg",
            "lbs",
            "gajbe",
            "l",
            "flaše"
        };
    }

    //private async void AddChangeBtn(object sender, EventArgs e)
    //{
    //    await AddChangeClick();
    //}

    //private async Task AddChangeClick()
    //{
    //    if (Product != null)
    //        await SetProduct();
    //    else
    //    {
    //        Product = new Product();
    //        await SetProduct();
    //    }

    //    if (Title == "Dodajanje izdelka")
    //    {
    //        var productsList = await MainService.GetAllProducts();
    //        if (productsList.Count > 0)
    //            Product.Id = productsList.LastOrDefault().Id + 1;
    //        else
    //            Product.Id = 0;
    //        await AddProduct(Product);
    //    }
    //    else
    //        await ChangeProduct(Product);
    //}

    //public async Task SetProduct()
    //{
    //    Product.Name = inpName.Text;
    //    Product.Unit = inpUnit.Text;

    //    if (inpMinLimit.Text != null)
    //    {
    //        if (await IsValidDouble(inpMinLimit.Text))
    //            Product.Min_qt_limit = double.Parse(inpMinLimit.Text);
    //        else
    //            await DisplayAlert("Opozorilo", "Za minimalno zlogo obvešèanja lahko uporabite samo število", "Zapri");
    //    }
    //    else
    //        await DisplayAlert("Opozorilo", "Za minimalno zlogo obvešèanja lahko uporabite samo število", "Zapri");
    //}
    //private async Task AddProduct(Product newProduct)
    //{
    //    await MainService.AddProduct(newProduct);
    //}
    //private async Task ChangeProduct(Product updatedProduct)
    //{
    //    await MainService.UpdateProduct(updatedProduct);
    //}

    //public Task<bool> IsValidDouble(string input)
    //{
    //    string pattern = @"^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$";
    //    return Task.FromResult(Regex.IsMatch(input, pattern));
    //}
}