using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Events
{
    public class EventMobs
    {
        public long EventId { get; set; }
        public long MobId { get; set; }
        public Dictionary.Mob Mob { get; set; }
        public Event Event { get; set; }
    }
}
