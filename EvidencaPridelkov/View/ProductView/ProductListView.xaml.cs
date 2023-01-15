using EvidencaPridelkov.Models;
using EvidencaPridelkov.ViewModels;

namespace EvidencaPridelkov.View.ProductView;

public partial class ProductListView : ContentPage
{
	private ProductViewModel viewModel;
	public ProductListView()
	{
		InitializeComponent();
		viewModel = new ProductViewModel(Navigation, this);
        viewModel.GetProductList();
        //ProductViewModel.GetProductList();
        BindingContext = viewModel;
	}

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    viewModel.GetProductList();
    //}

    //public async void DisplayAction(Product product)
    //{
    //    var response = await this.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
    //    //var response = await  AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
    //    if (response == "Edit")
    //    {
    //        await _navigation.PushAsync(new AddUpdateProductView(product));
    //    }
    //    else if (response == "Delete")
    //    {
    //        await MainService.DeleteProduct(product.Id);

    //    }
    //}

}