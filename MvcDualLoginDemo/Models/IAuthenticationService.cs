namespace MvcDualLoginDemo.Models
{
    public interface IAuthenticationService
    {
        void SignIn(string user, bool isPrimary);
        AppPrincipal GetAuthenticatedUser(bool isPrimary);
        void SignOut(bool isPrimary);
    }
}