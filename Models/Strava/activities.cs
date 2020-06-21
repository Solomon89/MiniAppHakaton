using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Strava
{
    public class activities
    {
        public string name { get; set; }
        public double distance { get; set; }
        public long id { get; set; }
        public string start_date { get; set; }
        public double max_speed { get; set; }
    }
}
