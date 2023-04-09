using System.Threading;
using System.Windows;
using System.Windows.Input;
using BOilerplate.Model;
using BOilerplate.Repository;
using FontAwesome.Sharp;

namespace BOilerplate.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private CustomerViewModel _customerViewModel;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

        public CustomerViewModel CustomerViewModel
        {
            get
            {
                return _customerViewModel;
            }

            set
            {
                _customerViewModel = value;
                OnPropertyChanged(nameof(CustomerViewModel));
            }
        }
        //Properties
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

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

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //--> Commands
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            CustomerViewModel = new CustomerViewModel();

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Customerssssssssssss";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetUserByName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.username;
                CurrentUserAccount.DisplayName = $"Welcome {user.name} {user.lastname}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid User not Logged In";
                Application.Current.Shutdown();
            }
        }
    }
}
