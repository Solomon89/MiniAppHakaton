using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Users
{
    public class UserBuildings
    {
        public int UserId { get; set; }
        public long BuildingId { get; set; }
        public Dictionary.Building Building { get; set; }
        public Identity.ApplicationUser User { get; set; }
    }
}
