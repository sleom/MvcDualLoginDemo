using System.Security.Principal;

namespace MvcDualLoginDemo.Models
{
    public class AppPrincipal : IPrincipal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppPrincipal"/> class.
        /// </summary>
        /// <param name="identity">The identity.</param>
        public AppPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        #region Implementation of IPrincipal

        /// <summary>
        /// Determines whether the current principal belongs to the specified role.
        /// </summary>
        /// <param name="role">The name of the role for which to check membership.</param>
        /// <returns>
        /// true if the current principal is a member of the specified role; otherwise, false.
        /// </returns>
        public bool IsInRole(string role)
        {
            return true; //roles currently not implemented
        }

        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <returns>The <see cref="T:System.Security.Principal.IIdentity" /> object associated with the current principal.</returns>
        public IIdentity Identity { get; private set; }

        #endregion

    }
}