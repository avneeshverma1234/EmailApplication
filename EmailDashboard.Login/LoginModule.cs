using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Shapes;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace EmailDashboard.Login
{
    public class LoginModule: IModule
    {
        [Dependency]
        public IUnityContainer Container
        { get; set; }
        public void Initialize()
        {
            LoginWorkItem loginWorkItem = Container.Resolve<LoginWorkItem>();
            loginWorkItem.Run();
        }
    }
}
