using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AmigosMauiV1.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        #region Properties
        private string? _userName;
        private string? _password;
        private string? _errorMessage;

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

        // Commands
        public ICommand? ShowPasswordCommand { get; }
        public ICommand? SignUpCommand { get; }
        #endregion

        public SignUpPageViewModel() 
        {
            IsBusy = false;
            SignUpCommand = new Command(SignUp, Validate); 
        }

        private void SignUp()
        {
            try
            {
                IsBusy = true; //Show lock screen
                Task.Delay(5000);

                IsBusy = false;
                ErrorMessage = "GoToMainPage";
            }
            catch (Exception ex)
            {
                IsBusy = false;
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
