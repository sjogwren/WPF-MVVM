using BOilerplate.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BOilerplate.Repository;
using System.Windows.Input;
using System.Windows;
using FontAwesome.Sharp;

namespace BOilerplate.ViewModel
{
    public class CustomerViewModel:ViewModelBase
    {
        //Fields
        private List<UserModel> _users;
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

        //Properties
        public List<UserModel> Users
        {
            get
            {
                return _users;
            }

            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
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

        public CustomerViewModel()
        {
            userRepository = new UserRepository();
            Users = GetAllUsers();
        }

        private List<UserModel> GetAllUsers()
        {
            var userList = userRepository.GetAll();
            return userList;
        }
    }
}
