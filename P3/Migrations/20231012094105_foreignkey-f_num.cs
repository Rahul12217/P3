using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P3.Migrations
{
    public partial class foreignkeyf_num : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlightsFlight_number",
                table: "TicketsTable",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketsTable_FlightsFlight_number",
                table: "TicketsTable",
                column: "FlightsFlight_number");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsTable_FlightTable_FlightsFlight_number",
                table: "TicketsTable",
                column: "FlightsFlight_number",
                principalTable: "FlightTable",
                principalColumn: "Flight_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketsTable_FlightTable_FlightsFlight_number",
                table: "TicketsTable");

            migrationBuilder.DropIndex(
                name: "IX_TicketsTable_FlightsFlight_number",
                table: "TicketsTable");

            migrationBuilder.DropColumn(
                name: "FlightsFlight_number",
                table: "TicketsTable");
        }
    }
}
