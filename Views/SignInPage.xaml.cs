using AmigosMauiV1.Helpers;
using AmigosMauiV1.Services;

namespace AmigosMauiV1.Views;

public partial class SignInPage : ContentPage
{
    private string _userName;
    private string _password;
    private bool _entryAsPassword;
    private bool _isDebugMode => true;
    private DBMokup _dBMokup;

    public bool IsSignInButtonEnabled
    {
        get => !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));
    }
    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName != value)
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(IsSignInButtonEnabled));
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
                OnPropertyChanged(nameof(IsSignInButtonEnabled));
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

        _dBMokup = new DBMokup();

        if (_isDebugMode)
        {
            UserName = "admin@mail.com";
            UserPassword = "admin";
        }
    }

    void OnTugglePasswordButtonClicked(object sender, EventArgs e)
    {
        var visBtn = sender as Button;
        if (EntryAsPassword)
            visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
        else
            visBtn!.Text = FontHelper.OPEN_EYE_ICON;
        EntryAsPassword = !EntryAsPassword;
    }

    void OnSignInButtonClicked(object sender, EventArgs e)
	{
        if(_dBMokup.isExist(UserName, UserPassword))
        {
            errorLbl.IsVisible = true;
            errorLbl.Text = "התחברות הצליחה";
            //Show a success message or navigate to the next page
        }
        else
        {
            errorLbl.IsVisible = true;
            errorLbl.Text = "שם משתמש או סיסמה שגויים";
            //DisplayAlert("Error", "Invalid username or password.", "OK");
        }
    }
}