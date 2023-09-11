using Microsoft.EntityFrameworkCore.Migrations;

namespace P3.Migrations
{
    public partial class @class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "TicketsTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "TicketsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
