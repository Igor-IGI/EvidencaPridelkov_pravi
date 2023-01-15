using EvidencaPridelkov.ViewModels;

namespace EvidencaPridelkov.View;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel(Navigation);
	}
}