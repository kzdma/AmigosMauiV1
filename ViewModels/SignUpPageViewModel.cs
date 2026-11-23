using AmigosMauiV1.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AmigosMauiV1.ViewModels
{
    public partial class SignUpPageViewModel : ObservableObject
    {
        #region Properties
        private string? _userName;
        private string? _password;
        private string? _errorMessage;
        private string? _passwordIconCode;

        [ObservableProperty]
        private bool _entryAsPassword;

        public string? UserName
        {
            get => _userName!;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                    //OnPropertyChanged(nameof(IsSignInButtonEnabled));
                    (SignUpCommand as Command)!.ChangeCanExecute();
                }
            }
        }
        public string? UserPassword
        {
            get => _password!;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(UserPassword));
                    //OnPropertyChanged(nameof(IsSignInButtonEnabled));
                    (SignUpCommand as Command)!.ChangeCanExecute();
                }
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage!;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }
        public string PasswordIconCode
        {
            get => _passwordIconCode!;
            set
            {
                if (_passwordIconCode != value)
                {
                    _passwordIconCode = value;
                    OnPropertyChanged(nameof(PasswordIconCode));
                }
            }
        }
        

        // Commands
        public ICommand? ShowPasswordCommand { get; }
        //public ICommand? SignUpCommand { get; }
        #endregion

        public SignUpPageViewModel() 
        {
            //IsBusy = false;
            PasswordIconCode = FontHelper.OPEN_EYE_ICON;
            ShowPasswordCommand = new Command(() =>
            {
                if (EntryAsPassword)
                    PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
                else
                    PasswordIconCode = FontHelper.OPEN_EYE_ICON;
                EntryAsPassword = !EntryAsPassword;
            });
            //SignUpCommand = new Command(SignUp, Validate); 
        }

        [RelayCommand]
        private void SignUp()
        {
            try
            {
                //IsBusy = true; //Show lock screen
                //Task.Delay(5000);

                //IsBusy = false;
                ErrorMessage = "GoToMainPage";
            }
            catch (Exception ex)
            {
                //IsBusy = false;
                ErrorMessage = ex.Message;
                //await Shell.Current.DisplayAlert("SignUp",ex.Message, "Cancel");
            }
        }
        private bool Validate()
        {
            return true;
        }
    }
}
