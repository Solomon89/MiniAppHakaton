using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.DTO
{
    [Serializable]
    public class StravaTrack
    {
        public StravaTrack()
        {
         

        }
        public double Lat { get; set; }
        public double Lon { get; set; }

    }
}
