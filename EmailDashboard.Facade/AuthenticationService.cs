using System;
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Threading;
using EmailDashboard.Facade.Interfaces;
using EmailDashboard.Web.Services.Authentication;

namespace EmailDashboard.Facade
{
    public class AuthenticationService:IAuthentication
    {
    //    private LoginOperation loginOperation;
     //   private bool isSuccessful;
        
        public void Login(string userName, string password,Action<bool> onCompleted)
        {
            LoginParameters loginParameters = new LoginParameters(userName, password);
            WebContextBase.Current.Authentication.Login(loginParameters,loginOperation_Completed,onCompleted);
          /*loginOperation.Completed += new System.EventHandler(loginOperation_Completed);
            while (!loginOperation.IsCanceled || !loginOperation.IsComplete || !loginOperation.IsErrorHandled)
            {
                Thread.Sleep(5000);      
            }
            return isSuccessful;*/
        }

        private void loginOperation_Completed(LoginOperation loginOperation)
        {
            Action<bool> callBack = loginOperation.UserState as Action<bool>;
            if (!loginOperation.HasError && loginOperation.LoginSuccess)
            {
                
                if(callBack!=null)
                {
                    callBack.Invoke(true);
                }
               
            }
            else
            {
                if (loginOperation.HasError)
                {
                    loginOperation.MarkErrorAsHandled();
                }
                if (callBack != null)
                {
                    callBack.Invoke(false);
                }
            }
        
        }
    }
}