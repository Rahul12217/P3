using Microsoft.EntityFrameworkCore.Migrations;

namespace P3.Migrations
{
    public partial class Three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TicketsTable_UserId",
                table: "TicketsTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsTable_UsersTable_UserId",
                table: "TicketsTable",
                column: "UserId",
                principalTable: "UsersTable",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketsTable_UsersTable_UserId",
                table: "TicketsTable");

            migrationBuilder.DropIndex(
                name: "IX_TicketsTable_UserId",
                table: "TicketsTable");
        }
    }
}
