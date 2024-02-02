using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FontAwesome.Sharp;

namespace ProduManUI.Core.ViewModels
{
    public class ProduManMainWindowViewModel : BaseViewModel
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private BaseViewModel _currentChildView;
        private string _caption;
        private IconChar _icon;
        //private IUserRepository userRepository;

        public ProduManMainWindowViewModel()
        {
            //userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            // Initialize commands
            ShowHomeViewCommand = new RelayCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new RelayCommand(ExecuteShowCustomerViewCommand);
            //Default view
            ExecuteShowHomeViewCommand(null);
            //LoadCurrentUserData();
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
        public BaseViewModel CurrentChildView
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

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Customers";
            Icon = IconChar.UserGroup;
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }
    }

    public  class UserAccountModel
    {
        private string _username = "TestowyName";
        public string DisplayName { get => _username; set => _username = value; }
    }
}
