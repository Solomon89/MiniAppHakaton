using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Dictionary
{
    public class Skill
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public ICollection<Users.UserSkills> UserSkills { get; set; }
    }
}
