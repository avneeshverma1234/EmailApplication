
using System.Windows;
using EmailDashboard.Facade;
using EmailDashboard.Facade.Interfaces;
using EmailDashboard.Login;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace EmailDashboard
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.RootVisual = (UIElement)this.Shell;
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            registerServices();
        }

        private void registerServices()
        {
            this.Container.RegisterType<IAuthentication, AuthenticationService>(new ContainerControlledLifetimeManager());   
            this.Container.RegisterType<IDomainFacade,DomainFacade>(new ContainerControlledLifetimeManager());

        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(LoginModule));
        }


    }
}
