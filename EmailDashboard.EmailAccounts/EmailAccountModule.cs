using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using EmailDashboard.Infrastructure;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace EmailDashboard.EmailAccounts
{
    public class EmailAccountModule : IModule
    {
        [Dependency]
        public IUnityContainer Container
        { get; set; }
        [Dependency]
        public EventAggregator EventAggregator { get; set; }
        [Dependency]
        public RegionManager RegionManager
        { get; set; }
        public void Initialize()
        {
            registerForLoginEvent();
        }

        private void registerForLoginEvent()
        {
            EventAggregator.GetEvent<LoginEvent>().Subscribe(loginOccurred,ThreadOption.UIThread,true);
        }

        private void loginOccurred(bool isSuccessful)
        {
            if(isSuccessful)
            {
                EmailAccountsUserControl emailAccountsUserControl = new EmailAccountsUserControl();
                emailAccountsUserControl.HeaderInfo = "Test";
                RegionManager.Regions["MainRegion"].Add(emailAccountsUserControl, "Test1");
            }
        }
    }
}
