using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniAppHakaton.Data;

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
        public OkObjectResult TrackQuery()
        {
            var trackList = new List<DTO.Track>();

            return Ok(trackList);
        }
    }
}
