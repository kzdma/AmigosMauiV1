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
    public class SignInViewModel : ObservableObject
    {
        private string? _userName;
        private string? _password;
        private bool _entryAsPassword;
        private bool _isMessageLableVisible;
        private string? _messageText;
        private Color? _messageColor;
        private bool _isDebugMode => true;
        private DBMokup? _dBMokup;

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

        // Commands
        public ICommand ShowPasswordCommand { get; }
        public ICommand SignInCommand { get; }


        public SignInViewModel()
        {
            ShowPasswordCommand = new Command(OnTugglePasswordButtonClicked);
            SignInCommand = new Command(OnSignInButtonClicked);
        }

        void OnTugglePasswordButtonClicked()
        {
            //var visBtn = sender as Button;
            //if (EntryAsPassword)
            //    visBtn!.Text = FontHelper.CLOSED_EYE_ICON;
            //else
            //    visBtn!.Text = FontHelper.OPEN_EYE_ICON;
            //EntryAsPassword = !EntryAsPassword;
        }

        void OnSignInButtonClicked()
        {
            //var btn = sender as Button;

            //if (_dBMokup.isExist(UserName, UserPassword))
            //{
            //    MessageText = MessagesHelper.SIGNINSUCCESSMESSAGE;
            //    MessageColor = Colors.Green;
            //    //Show a success message or navigate to the next page
            //}
            //else
            //{
            //    MessageText = MessagesHelper.SIGNINERRORMESSAGE;
            //    MessageColor = Colors.Red;
            //    //DisplayAlert("Error", "Invalid username or password.", "OK");
            //}
            //IsMessageLableVisible = true;
        }   
    }
}
