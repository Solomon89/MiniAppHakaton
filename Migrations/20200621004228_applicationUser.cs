using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MiniAppHakaton.Migrations
{
    public partial class applicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_event_User_created_by",
                schema: "events",
                table: "event");

            migrationBuilder.DropForeignKey(
                name: "FK_event_User_updated_by",
                schema: "events",
                table: "event");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaim_User_UserId",
                schema: "identity",
                table: "UserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_User_UserId",
                schema: "identity",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "identity",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToken_User_UserId",
                schema: "identity",
                table: "UserToken");

            migrationBuilder.DropForeignKey(
                name: "FK_achivment_User_user_id",
                schema: "users",
                table: "achivment");

            migrationBuilder.DropForeignKey(
                name: "FK_building_User_user_id",
                schema: "users",
                table: "building");

            migrationBuilder.DropForeignKey(
                name: "FK_events_User_user_id",
                schema: "users",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_skill_User_user_id",
                schema: "users",
                table: "skill");

            migrationBuilder.DropForeignKey(
                name: "FK_user_track_User_user_id",
                schema: "users",
                table: "user_track");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                schema: "identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "identity",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "identity",
                newName: "user",
                newSchema: "users");

            migrationBuilder.RenameColumn(
                name: "Gold",
                schema: "users",
                table: "user",
                newName: "gold");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "users",
                table: "user",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "users",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VKId",
                schema: "users",
                table: "user",
                newName: "vk_id");

            migrationBuilder.RenameColumn(
                name: "StravaRefreshToken",
                schema: "users",
                table: "user",
                newName: "strava_refresh_token");

            migrationBuilder.RenameColumn(
                name: "StravaId",
                schema: "users",
                table: "user",
                newName: "strava_id");

            migrationBuilder.RenameColumn(
                name: "StravaExpires",
                schema: "users",
                table: "user",
                newName: "strava_access_token");

            migrationBuilder.AlterColumn<string>(
                name: "vk_id",
                schema: "users",
                table: "user",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "users_user_PK",
                schema: "users",
                table: "user",
                column: "id");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_event_user_created_by",
                schema: "events",
                table: "event",
                column: "created_by",
                principalSchema: "users",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_event_user_updated_by",
                schema: "events",
                table: "event",
                column: "updated_by",
                principalSchema: "users",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaim_AspNetUsers_UserId",
                schema: "identity",
                table: "UserClaim",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_AspNetUsers_UserId",
                schema: "identity",
                table: "UserLogin",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_AspNetUsers_UserId",
                schema: "identity",
                table: "UserRole",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToken_AspNetUsers_UserId",
                schema: "identity",
                table: "UserToken",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_achivment_user_user_id",
                schema: "users",
                table: "achivment",
                column: "user_id",
                principalSchema: "users",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_building_user_user_id",
                schema: "users",
                table: "building",
                column: "user_id",
                principalSchema: "users",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_events_user_user_id",
                schema: "users",
                table: "events",
                column: "user_id",
                principalSchema: "users",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_skill_user_user_id",
                schema: "users",
                table: "skill",
                column: "user_id",
                principalSchema: "users",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_track_user_user_id",
                schema: "users",
                table: "user_track",
                column: "user_id",
                principalSchema: "users",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_event_user_created_by",
                schema: "events",
                table: "event");

            migrationBuilder.DropForeignKey(
                name: "FK_event_user_updated_by",
                schema: "events",
                table: "event");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaim_AspNetUsers_UserId",
                schema: "identity",
                table: "UserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_AspNetUsers_UserId",
                schema: "identity",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_AspNetUsers_UserId",
                schema: "identity",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToken_AspNetUsers_UserId",
                schema: "identity",
                table: "UserToken");

            migrationBuilder.DropForeignKey(
                name: "FK_achivment_user_user_id",
                schema: "users",
                table: "achivment");

            migrationBuilder.DropForeignKey(
                name: "FK_building_user_user_id",
                schema: "users",
                table: "building");

            migrationBuilder.DropForeignKey(
                name: "FK_events_user_user_id",
                schema: "users",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_skill_user_user_id",
                schema: "users",
                table: "skill");

            migrationBuilder.DropForeignKey(
                name: "FK_user_track_user_user_id",
                schema: "users",
                table: "user_track");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "users_user_PK",
                schema: "users",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                schema: "users",
                newName: "User",
                newSchema: "identity");

            migrationBuilder.RenameColumn(
                name: "gold",
                schema: "identity",
                table: "User",
                newName: "Gold");

            migrationBuilder.RenameColumn(
                name: "color",
                schema: "identity",
                table: "User",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "identity",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "vk_id",
                schema: "identity",
                table: "User",
                newName: "VKId");

            migrationBuilder.RenameColumn(
                name: "strava_refresh_token",
                schema: "identity",
                table: "User",
                newName: "StravaRefreshToken");

            migrationBuilder.RenameColumn(
                name: "strava_id",
                schema: "identity",
                table: "User",
                newName: "StravaId");

            migrationBuilder.RenameColumn(
                name: "strava_access_token",
                schema: "identity",
                table: "User",
                newName: "StravaExpires");

            migrationBuilder.AlterColumn<string>(
                name: "VKId",
                schema: "identity",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                schema: "identity",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "identity",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "identity",
                table: "User",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "identity",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                schema: "identity",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "identity",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                schema: "identity",
                table: "User",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                schema: "identity",
                table: "User",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "identity",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "identity",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "identity",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                schema: "identity",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                schema: "identity",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "identity",
                table: "User",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "identity",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "identity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "identity",
                table: "User",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_event_User_created_by",
                schema: "events",
                table: "event",
                column: "created_by",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_event_User_updated_by",
                schema: "events",
                table: "event",
                column: "updated_by",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaim_User_UserId",
                schema: "identity",
                table: "UserClaim",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_User_UserId",
                schema: "identity",
                table: "UserLogin",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "identity",
                table: "UserRole",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToken_User_UserId",
                schema: "identity",
                table: "UserToken",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_achivment_User_user_id",
                schema: "users",
                table: "achivment",
                column: "user_id",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_building_User_user_id",
                schema: "users",
                table: "building",
                column: "user_id",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_events_User_user_id",
                schema: "users",
                table: "events",
                column: "user_id",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_skill_User_user_id",
                schema: "users",
                table: "skill",
                column: "user_id",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_track_User_user_id",
                schema: "users",
                table: "user_track",
                column: "user_id",
                principalSchema: "identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
