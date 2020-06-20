using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Geomethry
{
    public class MobPoints
    {
        public long PointId { get; set; }
        public long MobId { get; set; }

        public Point Point { get; set; }
        public Dictionary.Mob Mob { get; set; }
    }
}
