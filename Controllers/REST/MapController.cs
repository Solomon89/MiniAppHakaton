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
    public class MapController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MapController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Test")]

        public IActionResult Test()
        {
            var xmlHelper = new Helpers.StravaTrackDeserializeHelper();
            var points = xmlHelper.XMLToListOfPoints("C:\\123.gpx");
            var track = new Models.Geomethry.Track();
            track.TracksPoints = new List<Models.Geomethry.TracksPoints>();
            _context.Tracks.Add(track);
            _context.SaveChanges();
            foreach (var p in points)
            {
                _context.Points.Add(p);
                _context.SaveChanges();
                _context.TracksPoints.Add(new TracksPoints { PointId = p.Id, TrackId = track.Id });
                _context.SaveChanges();
            }
            return Ok();

        } 


        [HttpGet]
        [Route("EventQuest")]
        public IActionResult Quest(int eventId, string type)
        {
            var quest = from Event in _context.Events
                        join Quest in _context.Quests on Event.Id equals Quest.EventId
                        join Track in _context.Tracks on Quest.TrackId equals Track.Id
                        where Event.Id == eventId
                        select new
                        {
                            id = Track.Id,
                            dist = Track.Distance,
                            time = Track.Time,
                            average_speed = Track.Time,
                            Points = (from TracPoints in _context.TracksPoints
                                      join Points in _context.Points on TracPoints.PointId equals Points.Id
                                      where TracPoints.TrackId == Track.Id
                                      select new
                                      {
                                          id = Points.Id,
                                          lat = Points.Lat,
                                          lon = Points.Lon
                                      }).ToList()
                        };
            return Ok(quest);
        }


        [HttpGet]
        [Route("ConquersBuilding")]
        public IActionResult RandomResponse()
        {
            Random randomizer = new Random();
            int a = randomizer.Next(0, 100);
            if (a >= 50)
            {
                return Ok();
            }
            else if (a < 50)
            {
                return StatusCode(400);
            }

            return Ok();
        }


        [HttpGet]
        [Route("MapInit")]
        public IActionResult MapInit(string vkId, double lat, double lon)
        {
            //var buildings = _context.Buildings.Include(i => i.BuildingPoints).Include(j => j.UserBuildings);




            var buildings = (from Building in _context.Buildings
                             join BuldingPoints in _context.BuildingPoints on Building.Id equals BuldingPoints.BuildingId
                             join Points in _context.Points on BuldingPoints.PointId equals Points.Id
                             select new
                             {
                                 id = Building.Id,


                                 eventId = (from EventBuildings in _context.EventBuildings
                                            join Events in _context.Events on EventBuildings.EventId equals Events.Id
                                            where EventBuildings.BuildingId == Building.Id
                                            select
                                                 Events.Id
                                            ).FirstOrDefault(),

                                 user = (from UserBuilding in _context.UserBuildings
                                         join Users in _context.ApplicationUsers on UserBuilding.UserId equals Users.Id
                                         where UserBuilding.BuildingId == Building.Id
                                         select new
                                         {
                                             color = Users.Color
                                         }).FirstOrDefault(),
                                 radius = Building.InfluenceRadius,
                                 lat = Points.Lat,
                                 lon = Points.Lon,
                                 name = Building.Name,
                                 icon = Building.Icon,
                                 type = "building"
                             }).ToList();



            var mobs = (from Mobs in _context.Mobs
                        join MobPoints in _context.MobPoints on Mobs.Id equals MobPoints.MobId
                        join Points in _context.Points on MobPoints.PointId equals Points.Id
                        select new
                        {
                            id = Mobs.Id,
                            eventId = (from EventMobs in _context.EventMobs
                                       join Events in _context.Events on EventMobs.EventId equals Events.Id
                                       where EventMobs.MobId == Mobs.Id
                                       select
                                            Events.Id
                                            ).FirstOrDefault(),
                            lat = Points.Lat,
                            lon = Points.Lon,
                            name = Mobs.Name,
                            icon = Mobs.Icon,
                            reward = Mobs.Reward,
                            type = "mob"
                        }).ToList();



            var events = (from Event in _context.Events
                          join EventPoints in _context.EventPoints on Event.Id equals EventPoints.EventId
                          join Points in _context.Points on EventPoints.PontId equals Points.Id
                          select new
                          {
                              id = Event.Id,


                              eventId = (from EventBuildings in _context.EventBuildings
                                         join Events in _context.Events on EventBuildings.EventId equals Events.Id
                                         where EventBuildings.BuildingId == Event.Id
                                         select
                                              Events.Id
                                         ).FirstOrDefault(),

                              reward = Event.Reward,
                              lat = Points.Lat,
                              lon = Points.Lon,
                              name = Event.Name,
                              icon = Event.Icon,
                              type = "event"
                          }).ToList();
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
            /*var building = from Buildings in _context.Buildings
                           join EventBuildings in _context.EventBuildings on Buildings.Id equals EventBuildings.BuildingId
                           join Event in _context.Events on EventBuildings.EventId equals Event.Id
                           join Quest in _context.Quests on Event.Id equals Quest.EventId
                           join Track in _context.Tracks on Quest.TrackId equals Track.Id
                           where Buildings.Id == 123
                           select new
                           {
                               id = Track.Id,
                               dist = Track.Distance,
                               time = Track.Time,
                               average_speed = Track.Time,
                               Points = (from TracPoints in _context.TracksPoints
                                         join Points in _context.Points on TracPoints.PointId equals Points.Id
                                         where TracPoints.TrackId == Track.Id
                                         select new
                                         {
                                             id = Points.Id,
                                             lat = Points.Lat,
                                             lon = Points.Lon
                                         }).ToList()
                           };
*/

            return Ok(new { buildings, mobs, events });
        }
    }
}
