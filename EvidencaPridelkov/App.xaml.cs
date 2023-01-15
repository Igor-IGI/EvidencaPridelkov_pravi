using EvidencaPridelkov.View;

namespace EvidencaPridelkov;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new LoginView());
	}
}
