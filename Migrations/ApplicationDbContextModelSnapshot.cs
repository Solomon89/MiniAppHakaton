﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniAppHakaton.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MiniAppHakaton.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Role","identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim","identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim","identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin","identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole","identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken","identity");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Dictionary.Achievement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("dictionary_achivment_PK");

                    b.ToTable("achivment","dictionary");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Dictionary.Armor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Damage")
                        .HasColumnName("damage")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("double precision");

                    b.HasKey("Id")
                        .HasName("dictionary_armor_PK");

                    b.ToTable("armor","dictionary");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Dictionary.Building", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<double>("InfluenceRadius")
                        .HasColumnName("influence_radius")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("dictionary_building_PK");

                    b.ToTable("building","dictionary");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Dictionary.Mob", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Icon")
                        .HasColumnName("icon")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<double>("Reward")
                        .HasColumnName("reward")
                        .HasColumnType("double precision");

                    b.HasKey("Id")
                        .HasName("dictionary_mob_PK");

                    b.ToTable("mob","dictionary");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Dictionary.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("double precision");

                    b.HasKey("Id")
                        .HasName("dictionary_skill_PK");

                    b.ToTable("skill","dictionary");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Events.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CreatedById")
                        .HasColumnName("created_by")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnName("date_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Icon")
                        .HasColumnName("icon")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<double>("Reward")
                        .HasColumnName("reward")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdatedById")
                        .HasColumnName("updated_by")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("events_event_PK");

                    b.HasIndex("CreatedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("event","events");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Events.EventBuildings", b =>
                {
                    b.Property<long>("EventId")
                        .HasColumnName("event_id")
                        .HasColumnType("bigint");

                    b.Property<long>("BuildingId")
                        .HasColumnName("building_id")
                        .HasColumnType("bigint");

                    b.HasKey("EventId", "BuildingId")
                        .HasName("events_building_PK");

                    b.HasIndex("BuildingId");

                    b.HasIndex("EventId");

                    b.ToTable("building","events");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Events.EventMobs", b =>
                {
                    b.Property<long>("EventId")
                        .HasColumnName("event_id")
                        .HasColumnType("bigint");

                    b.Property<long>("MobId")
                        .HasColumnName("mob_id")
                        .HasColumnType("bigint");

                    b.HasKey("EventId", "MobId")
                        .HasName("events_mob_PK");

                    b.HasIndex("EventId");

                    b.HasIndex("MobId");

                    b.ToTable("mob","events");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Events.EventPoints", b =>
                {
                    b.Property<long>("EventId")
                        .HasColumnName("event_id")
                        .HasColumnType("bigint");

                    b.Property<long>("PontId")
                        .HasColumnName("point_id")
                        .HasColumnType("bigint");

                    b.HasKey("EventId", "PontId")
                        .HasName("events_points_PK");

                    b.HasIndex("EventId");

                    b.HasIndex("PontId");

                    b.ToTable("points","events");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Events.Quest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("EventId")
                        .HasColumnName("event_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<long>("TrackId")
                        .HasColumnName("track_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("events_quest_PK");

                    b.HasIndex("EventId");

                    b.HasIndex("TrackId");

                    b.ToTable("quest","events");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Geomethry.BuildingPoints", b =>
                {
                    b.Property<long>("BuildingId")
                        .HasColumnName("building_id")
                        .HasColumnType("bigint");

                    b.Property<long>("PointId")
                        .HasColumnName("point_id")
                        .HasColumnType("bigint");

                    b.HasKey("BuildingId", "PointId")
                        .HasName("geomethry_building_PK");

                    b.HasIndex("BuildingId")
                        .HasName("IX_building_building_id1");

                    b.HasIndex("PointId");

                    b.ToTable("building","geomethry");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Geomethry.MobPoints", b =>
                {
                    b.Property<long>("MobId")
                        .HasColumnName("mob_id")
                        .HasColumnType("bigint");

                    b.Property<long>("PointId")
                        .HasColumnName("point_id")
                        .HasColumnType("bigint");

                    b.HasKey("MobId", "PointId")
                        .HasName("geomethry_mob_PK");

                    b.HasIndex("MobId");

                    b.HasIndex("PointId");

                    b.ToTable("Mob","geomethry");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Geomethry.Point", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Lat")
                        .HasColumnName("lat")
                        .HasColumnType("double precision");

                    b.Property<double>("Lon")
                        .HasColumnName("lat")
                        .HasColumnType("double precision");

                    b.HasKey("Id")
                        .HasName("geomethry_point_PK");

                    b.ToTable("point","geomethry");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Geomethry.Track", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("AverageSpeed")
                        .HasColumnName("average_speed")
                        .HasColumnType("double precision");

                    b.Property<double>("Distance")
                        .HasColumnName("distance")
                        .HasColumnType("double precision");

                    b.Property<long>("StravaTrackId")
                        .HasColumnName("strava_track_id")
                        .HasColumnType("bigint");

                    b.Property<double>("Time")
                        .HasColumnName("time")
                        .HasColumnType("double precision");

                    b.HasKey("Id")
                        .HasName("geomethry_track_PK");

                    b.ToTable("track","geomethry");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Geomethry.TracksPoints", b =>
                {
                    b.Property<long>("TrackId")
                        .HasColumnName("track_Id")
                        .HasColumnType("bigint");

                    b.Property<long>("PointId")
                        .HasColumnName("point_id")
                        .HasColumnType("bigint");

                    b.HasKey("TrackId", "PointId")
                        .HasName("geomethry_tracks_points_PK");

                    b.HasIndex("PointId");

                    b.HasIndex("TrackId");

                    b.ToTable("tracks_points","geomethry");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<double>("Gold")
                        .HasColumnType("double precision");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("StravaAccessToken")
                        .HasColumnType("text");

                    b.Property<long>("StravaExpires")
                        .HasColumnType("bigint");

                    b.Property<int>("StravaId")
                        .HasColumnType("integer");

                    b.Property<string>("StravaRefreshToken")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("VKId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("User","identity");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Users.UserAchivment", b =>
                {
                    b.Property<long>("AchivmentId")
                        .HasColumnName("achivment_id")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.HasKey("AchivmentId", "UserId")
                        .HasName("users_achivment_PK");

                    b.HasIndex("AchivmentId");

                    b.HasIndex("UserId");

                    b.ToTable("achivment","users");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Users.UserBuildings", b =>
                {
                    b.Property<long>("BuildingId")
                        .HasColumnName("building_id")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.HasKey("BuildingId", "UserId")
                        .HasName("users_building_PK");

                    b.HasIndex("BuildingId")
                        .HasName("IX_building_building_id2");

                    b.HasIndex("UserId");

                    b.ToTable("building","users");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Users.UserSkills", b =>
                {
                    b.Property<long>("SkillId")
                        .HasColumnName("skill_Id")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.HasKey("SkillId", "UserId")
                        .HasName("users_skills_PK");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("skill","users");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Users.UserTrack", b =>
                {
                    b.Property<long>("TrackId")
                        .HasColumnName("track_Id")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.HasKey("TrackId", "UserId")
                        .HasName("users_user_track_PK");

                    b.HasIndex("TrackId");

                    b.HasIndex("UserId");

                    b.ToTable("user_track","users");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Users.UsersEvent", b =>
                {
                    b.Property<long>("EventId")
                        .HasColumnName("event_id")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnName("state")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("EventId", "UserId")
                        .HasName("users_events_PK");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("events","users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Events.Event", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", "CreatedBy")
                        .WithMany("CreatedEvents")
                        .HasForeignKey("CreatedById");

                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", "UpdatedBy")
                        .WithMany("UpdatedEvents")
                        .HasForeignKey("UpdatedById");
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Events.EventBuildings", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Dictionary.Building", "Building")
                        .WithMany("EventBuildings")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Events.Event", "Event")
                        .WithMany("EventBuildings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Events.EventMobs", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Events.Event", "Event")
                        .WithMany("EventMobs")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Dictionary.Mob", "Mob")
                        .WithMany("EventMobs")
                        .HasForeignKey("MobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Events.EventPoints", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Events.Event", "Event")
                        .WithMany("EventPoints")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Geomethry.Point", "Point")
                        .WithMany("EventPoints")
                        .HasForeignKey("PontId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Events.Quest", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Events.Event", "Event")
                        .WithMany("Quests")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Geomethry.Track", "Track")
                        .WithMany("Quests")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Geomethry.BuildingPoints", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Dictionary.Building", "Building")
                        .WithMany("BuildingPoints")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Geomethry.Point", "Point")
                        .WithMany("BuildingPoints")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Geomethry.MobPoints", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Dictionary.Mob", "Mob")
                        .WithMany("MobPoints")
                        .HasForeignKey("MobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Geomethry.Point", "Point")
                        .WithMany("MobPoints")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Geomethry.TracksPoints", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Geomethry.Point", "Point")
                        .WithMany("TracksPoints")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Geomethry.Track", "Track")
                        .WithMany("TracksPoints")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Users.UserAchivment", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Dictionary.Achievement", "Achievement")
                        .WithMany("UserAchivments")
                        .HasForeignKey("AchivmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", "User")
                        .WithMany("UserAchivments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Users.UserBuildings", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Dictionary.Building", "Building")
                        .WithMany("UserBuildings")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", "User")
                        .WithMany("UserBuildings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Users.UserSkills", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Dictionary.Skill", "Skill")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Users.UserTrack", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Geomethry.Track", "Track")
                        .WithMany("UserTracks")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", "User")
                        .WithMany("UserTracks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniAppHakaton.Models.Users.UsersEvent", b =>
                {
                    b.HasOne("MiniAppHakaton.Models.Events.Event", "Event")
                        .WithMany("UserEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniAppHakaton.Models.Identity.ApplicationUser", "User")
                        .WithMany("UsersEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
