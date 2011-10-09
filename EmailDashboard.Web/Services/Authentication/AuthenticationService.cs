using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server.ApplicationServices;

namespace EmailDashboard.Web.Services.Authentication
{
    [EnableClientAccess]
    public class AuthenticationService : AuthenticationBase<User>
    {
    }
    public class User:UserBase
    {
        
    }
   
}