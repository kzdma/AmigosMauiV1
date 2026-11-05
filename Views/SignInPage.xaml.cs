using AmigosMauiV1.Helpers;

namespace AmigosMauiV1.Views;

public partial class SignInPage : ContentPage
{
    private string _userName;
    private string _password;
    private bool _entryAsPassword;

    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName != value)
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
    }
    public string UserPassword
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }
    }
    public bool EntryAsPassword
    {
        get => _entryAsPassword;
        set
        {
            if (_entryAsPassword != value)
            {
                _entryAsPassword = value;
                OnPropertyChanged(nameof(EntryAsPassword));
            }
        }
    }


    public SignInPage()
	{
		InitializeComponent();
        BindingContext= this;
        EntryAsPassword = true;
    }

	void OnSignInButtonClicked(object sender, EventArgs e)
	{
        var visBtn = sender as Button;
        if (EntryAsPassword)
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;

        EntryAsPassword = !EntryAsPassword;
    }
}