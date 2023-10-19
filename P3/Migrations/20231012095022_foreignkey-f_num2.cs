using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P3.Migrations
{
    public partial class foreignkeyf_num2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Flight_number",
                table: "TicketsTable",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsTable_Flight_number",
                table: "TicketsTable",
                column: "Flight_number");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsTable_FlightTable_Flight_number",
                table: "TicketsTable",
                column: "Flight_number",
                principalTable: "FlightTable",
                principalColumn: "Flight_number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketsTable_FlightTable_Flight_number",
                table: "TicketsTable");

            migrationBuilder.DropIndex(
                name: "IX_TicketsTable_Flight_number",
                table: "TicketsTable");

            migrationBuilder.AlterColumn<string>(
                name: "Flight_number",
                table: "TicketsTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
