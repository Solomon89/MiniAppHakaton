using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Geomethry
{
    public class Point
    {
        public long Id { get; set; }
        public long TrackId { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
