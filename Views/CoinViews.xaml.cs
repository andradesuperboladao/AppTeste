using AppTeste.ViewModels;

namespace AppTeste.Views;

public partial class CoinViews : ContentPage
{
	public CoinViews()
	{
        InitializeComponent();
        
        this.BindingContext = new CoinViewModel();
	}
}