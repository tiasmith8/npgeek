using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Web.Models;

namespace WebApplication.Web.Providers.Auth
{
    public interface IAuthProvider
    {
        /// <summary>
        /// Gets a value indicating whether returns true if a current user is logged in.
        /// </summary>
        /// <returns>Boolean</returns>
        bool IsLoggedIn { get; }

        /// <summary>
        /// Returns the current signed in user.
        /// </summary>
        /// <returns>User object</returns>
        User GetCurrentUser();

        /// <summary>
        /// Signs a user in.
        /// </summary>
        /// <param name="username">User's name</param>
        /// <param name="password">User's password</param>
        /// <returns>True if the user signed in.</returns>
        bool SignIn(string username, string password);

        /// <summary>
        /// Logs the user off from the system.
        /// </summary>
        void LogOff();

        /// <summary>
        /// Changes the logged in user's existing password.
        /// </summary>
        /// <param name="existingPassword">user's existing password</param>
        /// <param name="newPassword">user's new password</param>
        /// <returns>Boolean</returns>
        bool ChangePassword(string existingPassword, string newPassword);

        /// <summary>
        /// Creates a new user in the system.
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="password">User's password</param>
        /// <param name="role">User's role</param>
        void Register(string username, string password, string role);

        /// <summary>
        /// Checks to see if a user has a given role.
        /// </summary>
        /// <param name="roles">One of the roles that the user can belong to.</param>
        /// <returns>Boolean</returns>
        bool UserHasRole(string[] roles);
    }
}
