namespace MvcDualLoginDemo.Models
{
    public interface IMembershipService
    {
        bool ValidateUser(string username, string password);
    }
}