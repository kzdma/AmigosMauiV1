using AmigosMauiV1.ViewModels;

namespace AmigosMauiV1.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
		BindingContext = new SignUpPageViewModel();
	}
}