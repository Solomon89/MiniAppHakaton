using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MiniAppHakaton.Migrations
{
    public partial class version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "users_events_track_PK",
                schema: "users",
                table: "events");

            migrationBuilder.DropPrimaryKey(
                name: "users_achivment_track_PK",
                schema: "users",
                table: "achivment");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StravaAccessToken",
                schema: "identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StravaExpires",
                schema: "identity",
                table: "User",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "StravaId",
                schema: "identity",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StravaRefreshToken",
                schema: "identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VKId",
                schema: "identity",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "icon",
                schema: "dictionary",
                table: "mob",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                schema: "dictionary",
                table: "building",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                schema: "dictionary",
                table: "building",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "users_events_PK",
                schema: "users",
                table: "events",
                columns: new[] { "event_id", "user_id" });

            migrationBuilder.AddPrimaryKey(
                name: "users_achivment_PK",
                schema: "users",
                table: "achivment",
                columns: new[] { "achivment_id", "user_id" });

            migrationBuilder.CreateTable(
                name: "building",
                schema: "events",
                columns: table => new
                {
                    event_id = table.Column<long>(nullable: false),
                    building_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("events_building_PK", x => new { x.event_id, x.building_id });
                    table.ForeignKey(
                        name: "FK_building_building_building_id",
                        column: x => x.building_id,
                        principalSchema: "dictionary",
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_building_event_event_id",
                        column: x => x.event_id,
                        principalSchema: "events",
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mob",
                schema: "events",
                columns: table => new
                {
                    event_id = table.Column<long>(nullable: false),
                    mob_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("events_mob_PK", x => new { x.event_id, x.mob_id });
                    table.ForeignKey(
                        name: "FK_mob_event_event_id",
                        column: x => x.event_id,
                        principalSchema: "events",
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mob_mob_mob_id",
                        column: x => x.mob_id,
                        principalSchema: "dictionary",
                        principalTable: "mob",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building",
                schema: "geomethry",
                columns: table => new
                {
                    building_id = table.Column<long>(nullable: false),
                    point_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("geomethry_building_PK", x => new { x.building_id, x.point_id });
                    table.ForeignKey(
                        name: "FK_building_building_building_id",
                        column: x => x.building_id,
                        principalSchema: "dictionary",
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_building_point_point_id",
                        column: x => x.point_id,
                        principalSchema: "geomethry",
                        principalTable: "point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mob",
                schema: "geomethry",
                columns: table => new
                {
                    point_id = table.Column<long>(nullable: false),
                    mob_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("geomethry_mob_PK", x => new { x.mob_id, x.point_id });
                    table.ForeignKey(
                        name: "FK_Mob_mob_mob_id",
                        column: x => x.mob_id,
                        principalSchema: "dictionary",
                        principalTable: "mob",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mob_point_point_id",
                        column: x => x.point_id,
                        principalSchema: "geomethry",
                        principalTable: "point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "building",
                schema: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    building_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_building_PK", x => new { x.building_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_building_building_building_id",
                        column: x => x.building_id,
                        principalSchema: "dictionary",
                        principalTable: "building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_building_User_user_id",
                        column: x => x.user_id,
                        principalSchema: "identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_building_building_id",
                schema: "events",
                table: "building",
                column: "building_id");

            migrationBuilder.CreateIndex(
                name: "IX_building_event_id",
                schema: "events",
                table: "building",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_mob_event_id",
                schema: "events",
                table: "mob",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_mob_mob_id",
                schema: "events",
                table: "mob",
                column: "mob_id");

            migrationBuilder.CreateIndex(
                name: "IX_building_building_id1",
                schema: "geomethry",
                table: "building",
                column: "building_id");

            migrationBuilder.CreateIndex(
                name: "IX_building_point_id",
                schema: "geomethry",
                table: "building",
                column: "point_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mob_mob_id",
                schema: "geomethry",
                table: "Mob",
                column: "mob_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mob_point_id",
                schema: "geomethry",
                table: "Mob",
                column: "point_id");

            migrationBuilder.CreateIndex(
                name: "IX_building_building_id2",
                schema: "users",
                table: "building",
                column: "building_id");

            migrationBuilder.CreateIndex(
                name: "IX_building_user_id",
                schema: "users",
                table: "building",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "building",
                schema: "events");

            migrationBuilder.DropTable(
                name: "mob",
                schema: "events");

            migrationBuilder.DropTable(
                name: "building",
                schema: "geomethry");

            migrationBuilder.DropTable(
                name: "Mob",
                schema: "geomethry");

            migrationBuilder.DropTable(
                name: "building",
                schema: "users");

            migrationBuilder.DropPrimaryKey(
                name: "users_events_PK",
                schema: "users",
                table: "events");

            migrationBuilder.DropPrimaryKey(
                name: "users_achivment_PK",
                schema: "users",
                table: "achivment");

            migrationBuilder.DropColumn(
                name: "Color",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StravaAccessToken",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StravaExpires",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StravaId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StravaRefreshToken",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VKId",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "icon",
                schema: "dictionary",
                table: "mob");

            migrationBuilder.DropColumn(
                name: "Icon",
                schema: "dictionary",
                table: "building");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "dictionary",
                table: "building",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "users_events_track_PK",
                schema: "users",
                table: "events",
                columns: new[] { "event_id", "user_id" });

            migrationBuilder.AddPrimaryKey(
                name: "users_achivment_track_PK",
                schema: "users",
                table: "achivment",
                columns: new[] { "achivment_id", "user_id" });
        }
    }
}
