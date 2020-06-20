﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models.Dictionary
{
    public class Mob
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Reward { get; set; }
        public string Icon { get; set; }

        public ICollection<Events.EventMobs> EventMobs { get; set; }
        public ICollection<Geomethry.MobPoints> MobPoints { get; set; }
    }
}
