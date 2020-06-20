using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {

        public double Gold { get; set; }
        public ICollection<Users.UserTrack> UserTracks { get; set; }
        public ICollection<Users.UserAchivment> UserAchivments { get; set; }
        public ICollection<Users.UserSkills> UserSkills { get; set; }
        public ICollection<Events.Event> CreatedEvents { get; set; }
        public ICollection<Events.Event> UpdatedEvents { get; set; }
        public ICollection<Users.UsersEvent> UsersEvents { get; set; }
    }
}
