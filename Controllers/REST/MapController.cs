using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniAppHakaton.Data;
using MiniAppHakaton.Models.Identity;


namespace MiniAppHakaton.Controllers.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;             

    public MapController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
    }

        [HttpGet]
        public IActionResult Init(string vkId, double lat, double lon)
        {
            var users = _userManager.Users;
           // var currentUser = users.Where(ApplicationUser.VkId == vkId);


            return Ok();
        }
    }
}
