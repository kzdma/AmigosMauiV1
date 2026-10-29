using AmigosMauiV1.Helpers;

namespace AmigosMauiV1.Views;

public partial class SignInPage : ContentPage
{
	public SignInPage()
	{
		InitializeComponent();
	}

	void OnSignInButtonClicked(object sender, EventArgs e)
	{
        var visBtn = sender as Button;
        if (PasswordEntry.IsPassword)
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;

        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
    }
}