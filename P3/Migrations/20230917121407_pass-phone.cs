using Microsoft.EntityFrameworkCore.Migrations;

namespace P3.Migrations
{
    public partial class passphone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassengerPhone",
                table: "TicketsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengerPhone",
                table: "TicketsTable");
        }
    }
}
