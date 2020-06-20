using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Geomethry
{
    public class Track
    {
        public long Id { get; set; }
        public long StravaTrackId { get; set; }
        public ICollection<TracksPoints> TracksPoints { get; set; }
        public ICollection<Users.UserTrack> UserTracks { get; set; }
    }
}
