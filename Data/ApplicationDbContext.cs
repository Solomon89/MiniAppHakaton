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


        public DbSet<UserAchivment> Achivments { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Mob> Mobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Models.Events.Event> Events { get; set; }
        public DbSet<Models.Events.EventPoints> EventPoints { get; set; }
        public DbSet<Models.Events.Quest> Quests { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<TracksPoints> TracksPoints { get; set; }


        public DbSet<UserAchivment> UserAchivments { get; set; }
        public DbSet<UsersEvent> UsersEvents { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }
        public DbSet<UserTrack> UserTracks { get; set; }

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

            /////////// Схема dictionary ///////////////////

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.ToTable("achivment", "dictionary");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("dictionary_achivment_PK");

                entity.Property(e => e.Name)
                 .HasColumnName("name").HasMaxLength(255);
            });

            modelBuilder.Entity<Armor>(entity =>
            {
                entity.ToTable("armor", "dictionary");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("dictionary_armor_PK");

                entity.Property(e => e.Name)
                 .HasColumnName("name").HasMaxLength(255);
                entity.Property(e => e.Damage)
                 .HasColumnName("damage");
                entity.Property(e => e.Price)
                 .HasColumnName("price");
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

            modelBuilder.Entity<Mob>(entity =>
            {
                entity.ToTable("mob", "dictionary");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("dictionary_mob_PK");

                entity.Property(e => e.Name)
                 .HasColumnName("name").HasMaxLength(255);
                entity.Property(e => e.Reward)
                 .HasColumnName("reward");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill", "dictionary");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("dictionary_skill_PK");

                entity.Property(e => e.Name)
                 .HasColumnName("name").HasMaxLength(255);
                entity.Property(e => e.Price)
                 .HasColumnName("price");
            });



            ////////// схема Events /////////////////////
            modelBuilder.Entity<Models.Events.Event>(entity =>
            {
                entity.ToTable("event", "events");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("events_event_PK");

                entity.Property(e => e.Name)
                 .HasColumnName("name")
                 .HasMaxLength(255);


                entity.Property(e => e.Reward)
                 .HasColumnName("reward");

                entity.Property(e => e.CreatedAt)
                 .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                 .HasColumnName("created_at");

                entity.Property(e => e.EventDateTime)
                 .HasColumnName("date_time");



                entity.HasIndex(e => e.CreatedById);
                entity.Property(e => e.CreatedById).HasColumnName("created_by");
                entity.HasOne(p => p.CreatedBy)
                    .WithMany(c => c.CreatedEvents)
                    .HasForeignKey(d => d.CreatedById);


                entity.HasIndex(e => e.UpdatedById);
                entity.Property(e => e.UpdatedById).HasColumnName("updated_by");
                entity.HasOne(p => p.UpdatedBy)
                    .WithMany(c => c.UpdatedEvents)
                    .HasForeignKey(d => d.UpdatedById);

            });

            modelBuilder.Entity<Models.Events.EventPoints>(entity =>
            {
                entity.ToTable("points", "events");

                entity.HasKey(e => new { e.EventId, e.PontId }).HasName("events_points_PK");

                entity.HasIndex(e => e.EventId);
                entity.Property(e => e.EventId).HasColumnName("event_id");
                entity.HasOne(p => p.Event)
                    .WithMany(c => c.EventPoints)
                    .HasForeignKey(d => d.EventId);


                entity.HasIndex(e => e.PontId);
                entity.Property(e => e.PontId).HasColumnName("point_id");
                entity.HasOne(p => p.Point)
                    .WithMany(c => c.EventPoints)
                    .HasForeignKey(d => d.PontId);

            });

            modelBuilder.Entity<Models.Events.Quest>(entity =>
            {
                entity.ToTable("quest", "events");
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("events_quest_PK");

                entity.Property(e => e.Name)
                 .HasColumnName("name")
                 .HasMaxLength(255);

                entity.HasIndex(e => e.EventId);
                entity.Property(e => e.EventId).HasColumnName("event_id");
                entity.HasOne(p => p.Event)
                    .WithMany(c => c.Quests)
                    .HasForeignKey(d => d.EventId);


                entity.HasIndex(e => e.TrackId);
                entity.Property(e => e.TrackId).HasColumnName("track_id");
                entity.HasOne(p => p.Track)
                    .WithMany(c => c.Quests)
                    .HasForeignKey(d => d.TrackId);

            });





            /////////////// схема geomethry //////////////////

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


                entity.Property(e => e.Distance)
                 .HasColumnName("distance");

                entity.Property(e => e.Time)
                 .HasColumnName("time");

                entity.Property(e => e.AverageSpeed)
                 .HasColumnName("average_speed");

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



            /////// схема users

            modelBuilder.Entity<Models.Users.UserAchivment>(entity =>
            {
                entity.ToTable("achivment", "users");

                entity.HasKey(e => new { e.AchivmentId, e.UserId }).HasName("users_achivment_track_PK");

                entity.HasIndex(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.HasOne(p => p.User)
                    .WithMany(c => c.UserAchivments)
                    .HasForeignKey(d => d.UserId);

                entity.HasIndex(e => e.AchivmentId);
                entity.Property(e => e.AchivmentId).HasColumnName("achivment_id");
                entity.HasOne(p => p.Achievement)
                    .WithMany(c => c.UserAchivments)
                    .HasForeignKey(d => d.AchivmentId);
            });

            modelBuilder.Entity<Models.Users.UsersEvent>(entity =>
            {
                entity.ToTable("events", "users");

                entity.HasKey(e => new { e.EventId, e.UserId }).HasName("users_events_track_PK");


                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at"); 
                
                entity.Property(e => e.State)
                    .HasColumnName("state");

                entity.HasIndex(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.HasOne(p => p.User)
                    .WithMany(c => c.UsersEvents)
                    .HasForeignKey(d => d.UserId);

                entity.HasIndex(e => e.EventId);
                entity.Property(e => e.EventId).HasColumnName("event_id");
                entity.HasOne(p => p.Event)
                    .WithMany(c => c.UserEvents)
                    .HasForeignKey(d => d.EventId);
            });

            modelBuilder.Entity<Models.Users.UserSkills>(entity =>
            {
                entity.ToTable("skill", "users");

                entity.HasKey(e => new { e.SkillId, e.UserId }).HasName("users_skills_PK");

                entity.HasIndex(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.HasOne(p => p.User)
                    .WithMany(c => c.UserSkills)
                    .HasForeignKey(d => d.UserId);

                entity.HasIndex(e => e.SkillId);
                entity.Property(e => e.SkillId).HasColumnName("skill_Id");
                entity.HasOne(p => p.Skill)
                    .WithMany(c => c.UserSkills)
                    .HasForeignKey(d => d.SkillId);

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
