using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MiniAppHakaton.Models.Identity;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseIdentityColumns();
            modelBuilder.HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            modelBuilder.Entity<ApplicationUser>().ToTable("User", "identity");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Role", "identity");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim", "identity");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim", "identity");

            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin", "identity");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRole", "identity");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserToken", "identity");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Startup.Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
