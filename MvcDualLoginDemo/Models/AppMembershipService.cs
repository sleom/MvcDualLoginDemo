using System;

namespace MvcDualLoginDemo.Models
{
    public class AppMembershipService : IMembershipService
    {
        public bool ValidateUser(string username, string password)
        {
            return username.Equals(password, StringComparison.Ordinal);
        }
    }
}