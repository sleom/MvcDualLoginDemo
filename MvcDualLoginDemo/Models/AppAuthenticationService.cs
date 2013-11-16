using System;
using System.Diagnostics;
using System.Web;
using System.Web.Security;

namespace MvcDualLoginDemo.Models
{
    public class AppAuthenticationService : IAuthenticationService
    {
        public void SignIn(string user, bool isPrimary)
        {
            var userData = string.Empty;
            var username = user;
            if (!isPrimary)
            {
                var currUser = GetAuthenticatedUser(true);
                userData = user;
                username = currUser.Identity.Name;
            }
            var ticket = new FormsAuthenticationTicket(1, username, DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout), false, userData);
            var encTicket = FormsAuthentication.Encrypt(ticket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket){HttpOnly = true, Path = "/"});
        }

        public AppPrincipal GetAuthenticatedUser(bool isPrimary)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                try
                {
                    var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    return new AppPrincipal(new AppIdentity(isPrimary?authTicket.Name:authTicket.UserData, isPrimary));
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(string.Format("Ticket parsing exception:{0}", ex));
                }
            }
            return new AppPrincipal(new AppIdentity(null, false));

        }

        public void SignOut(bool isPrimary)
        {
            FormsAuthentication.SignOut();
        }
    }
}