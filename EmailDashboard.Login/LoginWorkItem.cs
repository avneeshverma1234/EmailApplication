using Microsoft.Practices.Unity;

namespace EmailDashboard.Login
{
    public class LoginWorkItem
    {
        [Dependency]
        public IUnityContainer Container
        { get; set; }
        public void Run()
        {
            LoginPresenter loginPresenter = Container.Resolve<LoginPresenter>();
            loginPresenter.DisplayLogin();
        }
    }
}