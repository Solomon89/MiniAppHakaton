using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Events
{
    public class EventPoints
    {
        public long PontId { get; set; }
        public long EventId { get; set; }

        public Event Event { get; set; }
        public Geomethry.Point Point { get; set; }
    }
}
