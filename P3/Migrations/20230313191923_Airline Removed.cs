using Microsoft.EntityFrameworkCore.Migrations;

namespace P3.Migrations
{
    public partial class AirlineRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airline",
                table: "FlightTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Airline",
                table: "FlightTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
