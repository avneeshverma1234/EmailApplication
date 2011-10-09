using System;

namespace EmailDashboard.Facade.Interfaces
{
    public interface  IAuthentication
    {
        void Login(string userName, string password,Action<bool> onCompleted);
    }
}