using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniAppHakaton.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Controllers
{
    public class StravaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public StravaController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Instructs the middleware to redirect to the Strava OAuth 2.0 user login screen.
        /// After successful OAuth authentication the athletes profile response data is 
        /// added to the current user identity.
        /// </summary>
        public IActionResult Connect()
        {
            /// The authenticationSchemes parameter must be set to "Strava".
            return Challenge(new AuthenticationProperties { RedirectUri = "Strava/Connected" }, "Strava");
        }
        public IActionResult AuthInStrava()
        {

            return new RedirectResult($"http://www.strava.com/oauth/authorize?client_id=49974&response_type=code&redirect_uri=http://alisaalena.ddns.net/strava/exchange_token&approval_prompt=force&scope=read");
        }
        public IActionResult exchange_token(string state, string code, string scope)
        {
            ViewData.Model = $"state {state},  code {code},  scope {scope}";
            return View();
        }
        /// <summary>
        /// Strava login callback. 
        /// </summary>
        public IActionResult Connected()
        {
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Deletes the authentication cookie.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
