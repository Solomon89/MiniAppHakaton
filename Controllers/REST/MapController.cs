using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniAppHakaton.Data;
using MiniAppHakaton.Models.Dictionary;
using MiniAppHakaton.Models.Events;
using MiniAppHakaton.Models.Geomethry;
using MiniAppHakaton.Models.Identity;
using Newtonsoft.Json;

namespace MiniAppHakaton.Controllers.REST
{

    [Route("Api/MapController")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
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
        [Route("MapInit")]
        public IActionResult MapInit(string vkId, double lat, double lon)
        {
            var currentUser = _userManager.Users.ToList().Find(user => user.VKId == vkId);

            //var buildings = _context.Buildings.Include(i => i.BuildingPoints).Include(j => j.UserBuildings);

            var buildings = from Building in _context.Buildings
                            join BuldingPoints in _context.BuildingPoints on Building.Id equals BuldingPoints.BuildingId
                            join Points in _context.Points on BuldingPoints.PointId equals Points.Id
                            join UserBuilding in _context.UserBuildings on Building.Id equals UserBuilding.BuildingId
                            select new
                            {
                                Lat = Points.Lat,
                                Lon = Points.Lon,
                                Name = Building.Name,
                                Icon = Building.Icon
                            };
            //buildings.ToArray();

            //var mobs = from Mob in _context.Mobs
            //           join MobPoints in _context.MobPoints on Mob.Id equals MobPoints.MobId
            //           join Points in _context.Points on MobPoints.PointId equals Points.Id
            //           select new
            //           {
            //               Lat = Points.Lat,
            //               Lon = Points.Lon,
            //               Name = Mob.Name,
            //               Icon = Mob.Icon
            //           };
            //// mobs.ToList();

            // var events = from Events in _context.Events
            //              join EventPoints in _context.EventPoints on Events.Id equals EventPoints.EventId
            //              join Points in _context.Points on EventPoints.PontId equals Points.Id
            //              select new
            //              {
            //                  Lat = Points.Lat,
            //                  Lon = Points.Lon,
            //                  Name = Events.Name                             
            //              };
            //events.ToList();
            return Ok(new { buildings = buildings });
        }
    }
}
