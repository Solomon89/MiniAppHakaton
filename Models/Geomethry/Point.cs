using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Geomethry
{
    public class Point
    {
        public long Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public ICollection<TracksPoints> TracksPoints { get; set; }
    }
}
