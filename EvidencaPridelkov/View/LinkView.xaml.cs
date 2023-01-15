using EvidencaPridelkov.ViewModels;

namespace EvidencaPridelkov.View;

public partial class LinkView : ContentPage
{
	public LinkView()
	{
		InitializeComponent();
        BindingContext = new LinkViewModel(Navigation);
    }
}