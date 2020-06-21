using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniAppHakaton.Migrations
{
    public partial class renameLon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "lon",
                schema: "geomethry",
                table: "point",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lon",
                schema: "geomethry",
                table: "point");
        }
    }
}
