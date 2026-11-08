using AmigosMauiV1.Helpers;
using AmigosMauiV1.Services;

namespace AmigosMauiV1.Views;

public partial class SignInPage : ContentPage
{
    private string _userName;
    private string _password;
    private bool _entryAsPassword;
    private bool _isMessageLableVisible;
    private string _messageText;
    private Color _messageColor;
    private bool _isDebugMode => true;
    private DBMokup _dBMokup;

    public bool IsSignInButtonEnabled
    {
        get => !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));
    }
    public bool IsMessageLableVisible
    {
        get => _isMessageLableVisible;
        set
        {
            if (_isMessageLableVisible != value)
            {
                _isMessageLableVisible = value;
                OnPropertyChanged(nameof(IsMessageLableVisible));
            }
        }
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
    public string MessageText
    {
        get => _messageText;
        set
        {
            if (_messageText != value)
            {
                _messageText = value;
                OnPropertyChanged(nameof(MessageText));
            }
        }
    }
    public Color MessageColor
    {
        get => _messageColor;
        set
        {
            if (_messageColor != value)
            {
                _messageColor = value;
                OnPropertyChanged(nameof(MessageColor));
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
        var btn = sender as Button;    

        if (_dBMokup.isExist(UserName, UserPassword))
        {          
            MessageText = MessagesHelper.SIGNINSUCCESSMESSAGE;
            MessageColor = Colors.Green;
            //Show a success message or navigate to the next page
        }
        else
        {
            MessageText = MessagesHelper.SIGNINERRORMESSAGE;
            MessageColor = Colors.Red;
            //DisplayAlert("Error", "Invalid username or password.", "OK");
        }
        IsMessageLableVisible = true;
    }  
}