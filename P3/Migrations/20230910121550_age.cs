using Microsoft.EntityFrameworkCore.Migrations;

namespace P3.Migrations
{
    public partial class age : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "TicketsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "TicketsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassengerName",
                table: "TicketsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "TicketsTable");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "TicketsTable");

            migrationBuilder.DropColumn(
                name: "PassengerName",
                table: "TicketsTable");
        }
    }
}
