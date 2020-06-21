using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniAppHakaton.Migrations
{
    public partial class addNotNulDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "users",
                table: "events",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "users",
                table: "events",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_time",
                schema: "events",
                table: "event",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "events",
                table: "event",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "events",
                table: "event",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "events",
                table: "event");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "users",
                table: "events",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "users",
                table: "events",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_time",
                schema: "events",
                table: "event",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "events",
                table: "event",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
