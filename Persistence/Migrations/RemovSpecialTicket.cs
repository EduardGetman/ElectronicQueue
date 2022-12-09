using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicQueue.Infrastructure.Persistence.Migrations
{
    public partial class RemovSpecialTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Ticket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Worker",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Ticket",
                type: "bit",
                nullable: true);
        }
    }
}
