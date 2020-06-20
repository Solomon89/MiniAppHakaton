using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Geomethry
{
    public class BuildingPoints
    {
        public long BuildingId { get; set; }
        public long PointId { get; set; }

        public Point Point { get; set; }
        public Dictionary.Building Building { get; set; }

    }
}