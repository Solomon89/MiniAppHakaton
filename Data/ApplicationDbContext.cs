using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MiniAppHakaton.Models;
using MiniAppHakaton.Models.Dictionary;
using MiniAppHakaton.Models.Geomethry;
using MiniAppHakaton.Models.Identity;
using MiniAppHakaton.Models.Users;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAppHakaton.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public DbSet<Test> Test { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<UserTrack> UserTracks { get; set; }
        public DbSet<TracksPoints> TracksPoints { get; set; }
        public DbSet<Building> Buildings { get; set; }

        //<summary>
        // 
        // </summary>
        // <param name = "options" ></ param >
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

            modelBuilder.Entity<Models.Test>(entity =>
            {
                entity.ToTable("test", "test");
                entity.Property(e => e.Id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("test_test_PK");

                entity.Property(e => e.TestField)
                 .HasColumnName("test_field");
            });

            modelBuilder.Entity<Models.Dictionary.Building>(entity =>
            {
                entity.ToTable("building", "dictionary");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("dictionary_building_PK");

                entity.Property(e => e.Name)
                 .HasColumnName("name")
                 .HasMaxLength(255);

                entity.Property(e => e.InfluenceRadius)
                 .HasColumnName("influence_radius");
            });


            modelBuilder.Entity<Models.Geomethry.Point>(entity =>
            {
                entity.ToTable("point", "geomethry");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("geomethry_point_PK");

                entity.Property(e => e.Lat)
                 .HasColumnName("lat");

                entity.Property(e => e.Lon)
                 .HasColumnName("lat");

            });

            modelBuilder.Entity<Models.Geomethry.Track>(entity =>
            {
                entity.ToTable("track", "geomethry");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("geomethry_track_PK");

                entity.Property(e => e.StravaTrackId)
                 .HasColumnName("strava_track_id");

            });

            modelBuilder.Entity<Models.Geomethry.TracksPoints>(entity =>
            {
                entity.ToTable("tracks_points", "geomethry");

                entity.HasKey(e => new { e.TrackId, e.PointId }).HasName("geomethry_tracks_points_PK");


                entity.HasIndex(e => e.PointId);
                entity.Property(e => e.PointId).HasColumnName("point_id");
                entity.HasOne(p => p.Point)
                    .WithMany(c => c.TracksPoints)
                    .HasForeignKey(d => d.PointId);

                entity.HasIndex(e => e.TrackId);
                entity.Property(e => e.TrackId).HasColumnName("track_Id");
                entity.HasOne(p => p.Track)
                    .WithMany(c => c.TracksPoints)
                    .HasForeignKey(d => d.TrackId);

            });

            modelBuilder.Entity<Models.Users.UserTrack>(entity =>
            {
                entity.ToTable("user_track", "users");

                entity.HasKey(e => new { e.TrackId, e.UserId }).HasName("users_user_track_PK");

                entity.HasIndex(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.HasOne(p => p.User)
                    .WithMany(c => c.UserTracks)
                    .HasForeignKey(d => d.UserId);

                entity.HasIndex(e => e.TrackId);
                entity.Property(e => e.TrackId).HasColumnName("track_Id");
                entity.HasOne(p => p.Track)
                    .WithMany(c => c.UserTracks)
                    .HasForeignKey(d => d.TrackId);

            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Startup.Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
