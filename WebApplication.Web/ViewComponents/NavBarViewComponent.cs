using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Web.Providers.Auth;

namespace WebApplication.Web.ViewComponents
{
    /// <summary>
    /// A view component is a reusable or "isolated" piece of our app.
    /// It cannot be navigated to via URL like a controller.
    /// </summary>
    public class NavBarViewComponent : ViewComponent
    {
        // Components allow dependency injection just like controllers.
        private readonly IAuthProvider authProvider;

        public NavBarViewComponent(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        /// <summary>
        /// This is the method that is invoked when the component is told to "render".
        /// </summary>
        /// <returns>IViewComponentResult</returns>
        public IViewComponentResult Invoke()
        {
            var user = this.authProvider.GetCurrentUser();
            return this.View("_NavBar", user);
        }
    }
}
