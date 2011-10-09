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
        public IRegionManager RegionManager
        { get; set; }
        public void DisplayLogin()
        {
            LoginViewModel loginViewModel = Container.Resolve<LoginViewModel>();
            LoginUserControl loginUserControl = new LoginUserControl();
            loginUserControl.DataContext = loginViewModel;
            RegionManager.Regions["MainRegion"].Add(loginUserControl);

        }
    }
}