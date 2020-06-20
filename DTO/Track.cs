using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.DTO
{
    public class Track
    {
        public int Id { get; set; }
        public ICollection<DTO.Point> TracksPoints { get; set; }

    }
}
