using AmigosMauiV1.Helpers;
using AmigosMauiV1.Services;
using AmigosMauiV1.ViewModels;

namespace AmigosMauiV1.Views;

public partial class SignInPage : ContentPage
{
    public SignInPage()
	{
		InitializeComponent();
        BindingContext = new SignInViewModel();

        EntryAsPassword = true;
        _dBMokup = new DBMokup();

        if (_isDebugMode)
        {
            UserName = "admin@mail.com";
            UserPassword = "admin";
        }
    }  
}