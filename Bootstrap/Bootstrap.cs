using Microsoft.EntityFrameworkCore;
using MiniAppHakaton.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Bootstrap
{
    public class Bootstrap
    {
        private readonly ApplicationDbContext applicationDbContext;

        public Bootstrap(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task Run()
        {
            applicationDbContext.Database.Migrate();
        }
    }
}
