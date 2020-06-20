using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Events
{
    public class Quest
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long TrackId { get; set; }
        public string Name { get; set; }
        public Geomethry.Track Track { get; set; }
        public Event Event { get; set; }
    }
}
