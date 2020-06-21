using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniAppHakaton.Core;
using MiniAppHakaton.Data;
using MiniAppHakaton.Models;
using MiniAppHakaton.Models.Strava;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
        [HttpGet]
        public IActionResult AuthInStrava(int VkId)
        {
            return new RedirectResult($"http://www.strava.com/oauth/authorize?client_id=49974&response_type=code&redirect_uri=http://alisaalena.ddns.net/strava/exchange_token&approval_prompt=force&scope=read,activity:read&VkI={VkId}");
        }
        private static readonly HttpClient client = new HttpClient();
        public async Task<JsonResult> exchange_token(string state, string code, string scope, string VkId)
        {
            ViewData.Model = $"state {state},  code {code},  scope {scope}";
            WebRequest request = WebRequest.Create("https://www.strava.com/oauth/token");
            request.Method = "Post";
            var values = new Dictionary<string, string>
            {
                { "client_id", "49974" },
                { "client_secret", "1c65ed360b40e351d59a9f4e5081fbe7b4bb87cf" },
                { "code", code },
                {"grant_type","authorization_code" }
            };
            var content = new FormUrlEncodedContent(values);
            try
            {
                var response = await client.PostAsync("https://www.strava.com/oauth/token", content);
                var responseString = await response.Content.ReadAsStringAsync();
                StravaModelToken ModelToken = JsonSerializer.Deserialize<StravaModelToken>(responseString);
                ViewData.Model = ModelToken.access_token;
                _modelToken = ModelToken;
                //AplicatuinUser user = _userManager.Users.ToList().Find(user => user.VKId == vkId);
                //user.
                return new JsonResult(ModelToken);
            }
            catch (Exception ex)
            {
                ViewData.Model = ex.Message;
            }
            //// Display the status.
            return null;
        }
        private static StravaModelToken _modelToken;
        public async Task<JsonResult> GetLastTrack(int Vkid, string access_token)
        {
            try
            {
                WebRequest request = WebRequest.Create("https://www.strava.com/api/v3/athlete/activities?per_page=5");
                request.Method = "Get";
                request.Headers.Add("Authorization", "Bearer " + access_token);
               
                var response = request.GetResponse();
                string responseFromServer;
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    
                }

                if (!responseFromServer.Contains("Authorization Error"))
                {
                    List<activities> activities = JsonSerializer.Deserialize<List<activities>>(responseFromServer);
                    return new JsonResult(activities);
                }
                else
                {
                    return new JsonResult("Проблемы с токеном");
                }


            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
            return null;
        }
        public async Task<string> GetDataFromBody(HttpResponse Response)
        {
            string data;
            using (StreamReader reader = new StreamReader(Response.Body))
            {
                data = await reader.ReadToEndAsync();
            }
            return data;
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
