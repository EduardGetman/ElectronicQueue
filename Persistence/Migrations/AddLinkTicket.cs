using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicQueue.Infrastructure.Persistence.Migrations
{
    public partial class AddLinkTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "СallingServicePointId",
                table: "Ticket",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_СallingServicePointId",
                table: "Ticket",
                column: "СallingServicePointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_ServicePoint_СallingServicePointId",
                table: "Ticket",
                column: "СallingServicePointId",
                principalTable: "ServicePoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_ServicePoint_СallingServicePointId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_СallingServicePointId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "СallingServicePointId",
                table: "Ticket");
        }
    }
}
