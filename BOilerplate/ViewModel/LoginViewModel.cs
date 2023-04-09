using BOilerplate.Model;
using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Input;
using BOilerplate.Repository;

namespace BOilerplate.ViewModel
{
    public class LoginViewModel :ViewModelBase
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isVisible = true;

        private IUserRepository _userRepository;
       public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand); 
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username))
            {
                validData = false;
            }
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var networkCredential = new System.Net.NetworkCredential(Username, Password);
            var validUser = _userRepository.AuthenticateUser(networkCredential);
            if (validUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
    new GenericIdentity(Username), null);
                IsVisible = false;
            }
            else
            {
                ErrorMessage = "Invalid username and password";
            }
        }
    }
}
