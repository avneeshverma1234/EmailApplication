using System.Windows;
using EmailDashboard.Facade.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;

namespace EmailDashboard.Login
{
    public class LoginViewModel
    {
        [Dependency]
        public IDomainFacade DomainFacade { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(loginUser);
        }

        private void loginUser()
        {
            DomainFacade.Authentication.Login(UserName, Password, OnLogin);
        }

        private void OnLogin(bool isSuccessful)
        {
            if(isSuccessful)
            {
                MessageBox.Show("Succeeded.....");
            }
            else
            {
                MessageBox.Show("Loging Failed. Please try again");
            }

        }

        public string UserName { get; set; }
        public string Password{ get; set; }
        public DelegateCommand LoginCommand { get; set; }

    }
}