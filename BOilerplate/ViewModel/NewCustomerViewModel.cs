using BOilerplate.Model;
using BOilerplate.Repository;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace BOilerplate.ViewModel
{
    public class NewCustomerViewModel: ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        private string _username;
        private string _name;
        private string _lastname;
        private string _email;
        private string _password;

        private IUserRepository userRepository;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string EMail
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(EMail));
            }
        }
        public ICommand SaveCommand { get; }

        public NewCustomerViewModel()
        {
            userRepository = new UserRepository();
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
        }

        private void ExecuteSaveCommand(object obj)
        {
            var user = new UserModel();
            var username = Thread.CurrentPrincipal.Identity.Name;
            user.name = Name;
            user.lastname = LastName;
            user.username = username;
            user.email = EMail;
            userRepository.Add(user);

        }

        private bool CanExecuteSaveCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
