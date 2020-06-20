using MiniAppHakaton.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Users
{
    public class UserAchivment
    {
        public int UserId { get; set; }
        public long AchivmentId { get; set; }
        public ApplicationUser User { get; set; }
        public Dictionary.Achievement Achievement { get; set; }
    }
}
