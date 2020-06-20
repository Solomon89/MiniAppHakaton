using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Events
{
    public class EventBuildings
    {
        public long EventId { get; set; }
        public long BuildingId { get; set; }

        public Dictionary.Building Building {get; set;}
        public Event Event {get; set;}

}
}
