using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Models
{
    public class StravaModelToken
    {
        public string token_type { get; set; }
        public long expires_at { get; set; }
        public long expires_in { get; set; }
        public string refresh_token { get; set; }
        public string access_token { get; set; }
        public athlete athlete { get; set; }
        public StravaModelToken()
        {
            athlete = new athlete();
        }
    }
    public class athlete
    {
        public int id { get; set; }
        public string username { get; set; }
        public int resource_state { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
}
