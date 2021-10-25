using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class FixingTripModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndAddress",
                table: "Trips",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartAddress",
                table: "Trips",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAddress",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StartAddress",
                table: "Trips");
        }
    }
}
