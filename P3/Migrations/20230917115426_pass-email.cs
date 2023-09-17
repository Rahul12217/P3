using Microsoft.EntityFrameworkCore.Migrations;

namespace P3.Migrations
{
    public partial class passemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassengerEmail",
                table: "TicketsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerEmail",
                table: "TicketsTable");
        }
    }
}
