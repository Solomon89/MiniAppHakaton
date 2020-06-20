using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Users
{
    public class UserTrack
    {
        public int UserId { get; set; }
        public long TrackId { get; set; }
        public Geomethry.Track Track { get; set; }
        public Identity.ApplicationUser User { get; set; }
    }
}
