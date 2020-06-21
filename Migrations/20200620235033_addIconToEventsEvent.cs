using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniAppHakaton.Migrations
{
    public partial class addIconToEventsEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icon",
                schema: "events",
                table: "event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icon",
                schema: "events",
                table: "event");
        }
    }
}
