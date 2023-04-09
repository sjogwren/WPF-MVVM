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

        private IUserRepository userRepository;

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
