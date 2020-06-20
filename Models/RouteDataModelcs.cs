using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models
{
    public class RouteDataModelcs
    {
        public int Id { get; set; }
        public string fromPoint { get; set; }
        public string toPoint { get; set; }
        public string? routeDistance { get; set; }
    }
}
