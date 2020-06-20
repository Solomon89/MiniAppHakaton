using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniAppHakaton.Data;
using MiniAppHakaton.DTO;
using MiniAppHakaton.Models.Geomethry;
using MiniAppHakaton.Models.Users;

namespace MiniAppHakaton.Controllers.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrackController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TrackQuery(object query)
        {
            if (query!=null)
            {
                var trackList = new List<DTO.Track>();
                //trackList = from TrackId in _context.UserTracks
                //            where (UserId == query.request.data.User.Id)
                //            select 

                

                return Ok(trackList);
            }
            return Ok();
            
        }
    }
}
