using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Users
{
    public class UserSkills
    {
        public int UserId { get; set; }
        public long SkillId { get; set; }

        public Identity.ApplicationUser User { get; set; }
        public Dictionary.Skill Skill { get; set; }
    }
}
