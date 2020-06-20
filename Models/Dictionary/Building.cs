using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Dictionary
{
    public class Building
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double InfluenceRadius { get; set; }
        public string Icon { get; set; }

        public ICollection<Geomethry.BuildingPoints> BuildingPoints { get; set; }
        public ICollection<Events.EventBuildings> EventBuildings { get; set; }
        public ICollection<Users.UserBuildings> UserBuildings { get; set; }

    }
}
