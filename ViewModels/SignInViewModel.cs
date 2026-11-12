using AmigosMauiV1.Helpers;
using AmigosMauiV1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AmigosMauiV1.ViewModels
{
    public class SignInViewModel : ViewModelBase //ObservableObject
    {
        private string? _togglePasswordButtonText;
        private string? _userName;
        private string? _password;
        private bool _entryAsPassword;
        private bool _isMessageLableVisible;
        private string? _messageText;
        private Color? _messageColor;
        private bool _isDebugMode => true;
        private DBMokup? _dBMokup;

        public string TogglePasswordButtonText
        {
            get => _togglePasswordButtonText!;
            set
            {
                if (_togglePasswordButtonText != value)
                {
                    _togglePasswordButtonText = value;
                    OnPropertyChanged(nameof(TogglePasswordButtonText));
                }
            }
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
            get => _userName!;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                    //OnPropertyChanged(nameof(IsSignInButtonEnabled));
                    (SignInCommand as Command)!.ChangeCanExecute();
                }
            }
        }
        public string UserPassword
        {
            get => _password!;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(UserPassword));
                    //OnPropertyChanged(nameof(IsSignInButtonEnabled));
                    (SignInCommand as Command)!.ChangeCanExecute();
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

        // Commands
        public ICommand ShowPasswordCommand { get; }
        public ICommand SignInCommand { get; }


        public SignInViewModel()
        {
            //ShowPasswordCommand = new Command(OnTugglePasswordButtonClicked);

            //Using a lambda expression to define the command action
            ShowPasswordCommand = new Command(() => 
            {
                if (EntryAsPassword)
                    TogglePasswordButtonText = FontHelper.CLOSED_EYE_ICON;
                else
                    TogglePasswordButtonText = FontHelper.OPEN_EYE_ICON;
                EntryAsPassword = !EntryAsPassword;
            });

            SignInCommand = new Command(OnSignInButtonClicked, CanSignIn);

            TogglePasswordButtonText = FontHelper.CLOSED_EYE_ICON;

            EntryAsPassword = true;
            _dBMokup = new DBMokup();

            if (_isDebugMode)
            {
                UserName = "admin@mail.com";
                UserPassword = "admin";
            }
        }

        void OnSignInButtonClicked()
        {
            if (_dBMokup!.IsExist(UserName, UserPassword))
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
        private bool CanSignIn()
        {
            return !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));
        }
    }
}
