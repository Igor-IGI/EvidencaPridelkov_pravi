using EvidencaPridelkov.Models;
using EvidencaPridelkov.ViewModels;

namespace EvidencaPridelkov.View.ProductView;

public partial class ChangeProductView : ContentPage
{
    public Product Product { get; private set; }
    public ChangeProductView(Product product = null)
    {
        if (product != null)
            Product = product;

        BindingContext = new ChangeProductViewModel(Navigation, this);
        InitializeComponent();
    }
}