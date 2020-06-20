using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Users
{
    public class UsersEvent
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public long EventId { get; set; }
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Identity.ApplicationUser User { get; set; }
        public Events.Event Event { get; set; }

    }
}
