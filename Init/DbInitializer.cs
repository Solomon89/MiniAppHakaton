using MiniAppHakaton.Data;
using MiniAppHakaton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Init
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            ////// добавляю точки //////////////
            if (_context.Points.ToList().Count == 0)
            {
                _context.Points.AddRange(new List<Models.Geomethry.Point> {
                    new Models.Geomethry.Point { Id = 21, Lat = 55.729970, Lon = 37.747379 },
                    new Models.Geomethry.Point { Id = 22, Lat = 55.729600, Lon = 37.750775 },
                    new Models.Geomethry.Point { Id = 23, Lat = 55.728484, Lon = 37.748107 },
                    new Models.Geomethry.Point { Id = 24, Lat = 55.731212, Lon = 37.749328 }
                });
            }
            if (_context.Buildings.ToList().Count == 0)
            {
                _context.Buildings.AddRange(new List<Models.Dictionary.Building> {
                    new Models.Dictionary.Building { Id = 31, Name = "Башня славы великих дотнетчиков",  Icon = "fortress.png"},
                    new Models.Dictionary.Building { Id = 32, Name = "Башня славы великих джавистов",  Icon = "fortress.png"}
                });
            }

            if (_context.Events.ToList().Count == 0)
            {
                _context.Events.Add(
                    new Models.Events.Event { Id = 13, Name = "Супер модный забег от Nike, во имя запуска ConquerRun", Icon = "fortress.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Reward = 1000, EventDateTime = DateTime.Now + TimeSpan.FromHours(20) }
                );
            }

            if (_context.Mobs.ToList().Count == 0)
            {
                _context.Mobs.Add(
                    new Models.Dictionary.Mob { Id = 43, Name = "Безсонная ночь", Icon = "mobIcon.png", Reward = 150000 }
                );
            }

            if (_context.ApplicationUsers.Find(12) == null)
            {
                _context.ApplicationUsers.Add(
                   new Models.Identity.ApplicationUser { Id = 12, VKId = "168260221", Color = "пастельный зеленый цвет", Gold = 104000 }
               );
            }

            if (_context.UserBuildings.ToList().Count == 0)
            {
                _context.UserBuildings.Add(
                   new Models.Users.UserBuildings { UserId = 12, BuildingId = 31 }
               );
            }

            if (_context.BuildingPoints.ToList().Count == 0)
            {
                _context.BuildingPoints.Add(
                   new Models.Geomethry.BuildingPoints { PointId = 23, BuildingId = 31 }
                   );
            }
            if (_context.EventPoints.ToList().Count == 0)
            {
                _context.EventPoints.Add(
                   new Models.Events.EventPoints { EventId = 13, PontId = 24 }
               );
            }
            if (_context.MobPoints.ToList().Count == 0)
            {
                _context.MobPoints.Add(
                   new Models.Geomethry.MobPoints { MobId = 43, PointId = 24 }
               );
            }


            _context.SaveChanges();
        }
    }
}
