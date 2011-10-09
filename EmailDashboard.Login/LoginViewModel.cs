using System;
using System.ComponentModel;
using System.Windows;
using EmailDashboard.Facade.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;

namespace EmailDashboard.Login
{
    public class LoginViewModel:INotifyPropertyChanged
    {
        private bool isBusy;
        public event EventHandler OnLoginSuccessful;
        [Dependency]
        public IDomainFacade DomainFacade { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(loginUser);
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
                }
            }
        }
        private void loginUser()
        {
            IsBusy = true;
            DomainFacade.Authentication.Login(UserName, Password, OnLogin);
        }

        private void OnLogin(bool isSuccessful)
        {
            IsBusy = false;
            if(isSuccessful)
            {
                if (OnLoginSuccessful != null)
                {
                    OnLoginSuccessful(this, EventArgs.Empty);
                }
            }
            else
            {
                MessageBox.Show("Loging Failed. Please try again");
            }

        }

        public string UserName { get; set; }
        public string Password{ get; set; }
        public DelegateCommand LoginCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}