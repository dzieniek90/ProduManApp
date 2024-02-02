using ProduManUI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProduManUI.Core.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        //Constructor
        public LoginWindowViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new RelayCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        //Properties
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

        public SecureString Password
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

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }



        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            //var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            //if (isValidUser)
            //{
            //    Thread.CurrentPrincipal = new GenericPrincipal(
            //        new GenericIdentity(Username), null);
                IsViewVisible = false;
            //}
            //else
            //{
            //    ErrorMessage = "* Invalid username or password";
            //}
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

    }
}
