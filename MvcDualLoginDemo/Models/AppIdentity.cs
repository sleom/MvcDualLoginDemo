using System.Security.Principal;

namespace MvcDualLoginDemo.Models
{
    public class AppIdentity : IIdentity
    {
        public AppIdentity(string name, bool isPrimary)
        {
            Name = name;
            IsPrimary = isPrimary;
        }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns>The name of the user on whose behalf the code is running.</returns>
        public string Name { get; private set; }

        public bool IsPrimary { get; private set; }

        /// <summary>
        /// Gets the type of authentication used.
        /// </summary>
        /// <returns>The type of authentication used to identify the user.</returns>
        public string AuthenticationType
        {
            get { return "Forms"; }
        }

        /// <summary>
        /// Gets a value that indicates whether the user has been authenticated.
        /// </summary>
        /// <returns>true if the user was authenticated; otherwise, false.</returns>
        public bool IsAuthenticated { get { return !string.IsNullOrWhiteSpace(Name); } }
    }
}