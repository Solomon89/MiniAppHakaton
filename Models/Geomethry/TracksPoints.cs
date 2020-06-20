using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Geomethry
{
    public class TracksPoints
    {
        public long TrackId { get; set; }
        public long PointId { get; set; }

        public Track Track { get; set; }
        public Point Point { get; set; }
    }
}
