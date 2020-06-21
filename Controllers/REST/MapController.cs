﻿using System;
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
                                user = (from UserBuilding in _context.UserBuildings
                                       join Users in _context.ApplicationUsers on UserBuilding.UserId equals Users.Id
                                        where UserBuilding.BuildingId == Building.Id
                                       select new
                                       {
                                           color = Users.Color
                                       }).FirstOrDefault(),
                                Radius = Building.InfluenceRadius,
                                Lat = Points.Lat,
                                Lon = Points.Lon,
                                Name = Building.Name,
                                Icon = Building.Icon
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
            return Ok(buildings);
        }
    }
}
