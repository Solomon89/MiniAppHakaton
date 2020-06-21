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
            _context.Points.AddRange(new List<Models.Geomethry.Point> {
                new Models.Geomethry.Point { Id = 21, Lat = 55.729970, Lon = 37.747379 },
                new Models.Geomethry.Point { Id = 22, Lat = 55.729600, Lon = 37.750775 },
                new Models.Geomethry.Point { Id = 23, Lat = 55.728484, Lon = 37.748107 },
                new Models.Geomethry.Point { Id = 24, Lat = 55.731212, Lon = 37.749328 }
            });



            _context.Buildings.AddRange(new List<Models.Dictionary.Building> {
                new Models.Dictionary.Building { Id = 31, Name = "Башня славы великих дотнетчиков",  Icon = "fortress.png"},
                new Models.Dictionary.Building { Id = 32, Name = "Башня славы великих джавистов",  Icon = "fortress.png"}
            });

            _context.Events.Add(
                new Models.Events.Event { Id = 13, Name = "Супер модный забег от Nike, во имя запуска ConquerRun", Icon = "fortress.png", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Reward = 1000, EventDateTime = DateTime.Now + TimeSpan.FromHours(20) }
            );






        }
    }
}
