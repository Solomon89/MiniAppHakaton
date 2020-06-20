using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MiniAppHakaton.Migrations
{
    public partial class version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "test",
                schema: "test");

            migrationBuilder.EnsureSchema(
                name: "events");

            migrationBuilder.AddColumn<double>(
                name: "Gold",
                schema: "identity",
                table: "User",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "average_speed",
                schema: "geomethry",
                table: "track",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "distance",
                schema: "geomethry",
                table: "track",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "time",
                schema: "geomethry",
                table: "track",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "achivment",
                schema: "dictionary",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dictionary_achivment_PK", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "armor",
                schema: "dictionary",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    damage = table.Column<double>(nullable: false),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dictionary_armor_PK", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mob",
                schema: "dictionary",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    reward = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dictionary_mob_PK", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                schema: "dictionary",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("dictionary_skill_PK", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "event",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    date_time = table.Column<DateTime>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    reward = table.Column<double>(nullable: false),
                    created_by = table.Column<int>(nullable: true),
                    updated_by = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("events_event_PK", x => x.id);
                    table.ForeignKey(
                        name: "FK_event_User_created_by",
                        column: x => x.created_by,
                        principalSchema: "identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_event_User_updated_by",
                        column: x => x.updated_by,
                        principalSchema: "identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "achivment",
                schema: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    achivment_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_achivment_track_PK", x => new { x.achivment_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_achivment_achivment_achivment_id",
                        column: x => x.achivment_id,
                        principalSchema: "dictionary",
                        principalTable: "achivment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_achivment_User_user_id",
                        column: x => x.user_id,
                        principalSchema: "identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                schema: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    skill_Id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_skills_PK", x => new { x.skill_Id, x.user_id });
                    table.ForeignKey(
                        name: "FK_skill_skill_skill_Id",
                        column: x => x.skill_Id,
                        principalSchema: "dictionary",
                        principalTable: "skill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skill_User_user_id",
                        column: x => x.user_id,
                        principalSchema: "identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "points",
                schema: "events",
                columns: table => new
                {
                    point_id = table.Column<long>(nullable: false),
                    event_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("events_points_PK", x => new { x.event_id, x.point_id });
                    table.ForeignKey(
                        name: "FK_points_event_event_id",
                        column: x => x.event_id,
                        principalSchema: "events",
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_points_point_point_id",
                        column: x => x.point_id,
                        principalSchema: "geomethry",
                        principalTable: "point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quest",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    event_id = table.Column<long>(nullable: false),
                    track_id = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("events_quest_PK", x => x.id);
                    table.ForeignKey(
                        name: "FK_quest_event_event_id",
                        column: x => x.event_id,
                        principalSchema: "events",
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quest_track_track_id",
                        column: x => x.track_id,
                        principalSchema: "geomethry",
                        principalTable: "track",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                schema: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    event_id = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    state = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_events_track_PK", x => new { x.event_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_events_event_event_id",
                        column: x => x.event_id,
                        principalSchema: "events",
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_events_User_user_id",
                        column: x => x.user_id,
                        principalSchema: "identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_event_created_by",
                schema: "events",
                table: "event",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_event_updated_by",
                schema: "events",
                table: "event",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_points_event_id",
                schema: "events",
                table: "points",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_points_point_id",
                schema: "events",
                table: "points",
                column: "point_id");

            migrationBuilder.CreateIndex(
                name: "IX_quest_event_id",
                schema: "events",
                table: "quest",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_quest_track_id",
                schema: "events",
                table: "quest",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_achivment_achivment_id",
                schema: "users",
                table: "achivment",
                column: "achivment_id");

            migrationBuilder.CreateIndex(
                name: "IX_achivment_user_id",
                schema: "users",
                table: "achivment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_events_event_id",
                schema: "users",
                table: "events",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_events_user_id",
                schema: "users",
                table: "events",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_skill_skill_Id",
                schema: "users",
                table: "skill",
                column: "skill_Id");

            migrationBuilder.CreateIndex(
                name: "IX_skill_user_id",
                schema: "users",
                table: "skill",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "armor",
                schema: "dictionary");

            migrationBuilder.DropTable(
                name: "mob",
                schema: "dictionary");

            migrationBuilder.DropTable(
                name: "points",
                schema: "events");

            migrationBuilder.DropTable(
                name: "quest",
                schema: "events");

            migrationBuilder.DropTable(
                name: "achivment",
                schema: "users");

            migrationBuilder.DropTable(
                name: "events",
                schema: "users");

            migrationBuilder.DropTable(
                name: "skill",
                schema: "users");

            migrationBuilder.DropTable(
                name: "achivment",
                schema: "dictionary");

            migrationBuilder.DropTable(
                name: "event",
                schema: "events");

            migrationBuilder.DropTable(
                name: "skill",
                schema: "dictionary");

            migrationBuilder.DropColumn(
                name: "Gold",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "average_speed",
                schema: "geomethry",
                table: "track");

            migrationBuilder.DropColumn(
                name: "distance",
                schema: "geomethry",
                table: "track");

            migrationBuilder.DropColumn(
                name: "time",
                schema: "geomethry",
                table: "track");

            migrationBuilder.EnsureSchema(
                name: "test");

            migrationBuilder.CreateTable(
                name: "test",
                schema: "test",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    test_field = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("test_test_PK", x => x.id);
                });
        }
    }
}
