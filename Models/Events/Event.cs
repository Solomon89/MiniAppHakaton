using MiniAppHakaton.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Events
{
    public class Event
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public DateTime EventDateTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double Reward { get; set; }
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }

        public ApplicationUser CreatedBy { get; set; }
        public ApplicationUser UpdatedBy { get; set; }


        public ICollection<Events.Quest> Quests { get; set; }
        public ICollection<Events.EventPoints> EventPoints { get; set; }
        public ICollection<Users.UsersEvent> UserEvents { get; set; }
        public ICollection<Events.EventMobs> EventMobs { get; set; }
        public ICollection<Events.EventBuildings> EventBuildings { get; set; }


    }
}
