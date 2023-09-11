using Microsoft.EntityFrameworkCore.Migrations;

namespace P3.Migrations
{
    public partial class AddedFareandflight_number : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fare",
                table: "TicketsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Flight_number",
                table: "TicketsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fare",
                table: "TicketsTable");

            migrationBuilder.DropColumn(
                name: "Flight_number",
                table: "TicketsTable");
        }
    }
}
