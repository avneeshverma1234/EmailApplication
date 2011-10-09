using System;
using EmailDashboard.Infrastructure;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace EmailDashboard.Login
{
    public class LoginPresenter
    {
        [Dependency]
        public IUnityContainer Container
        { get; set; }
        [Dependency]
        public EventAggregator EventAggregator { get; set; }
        public void DisplayLogin()
        {
            var loginWindow = new LoginWindow();
            var loginViewModel = Container.Resolve<LoginViewModel>();
            loginViewModel.OnLoginSuccessful += (sender, e) => { loginWindow.Close();
            EventAggregator.GetEvent<LoginEvent>().Publish(true);};
            loginWindow.DataContext = loginViewModel;
            loginWindow.Show();
        }
    }
}