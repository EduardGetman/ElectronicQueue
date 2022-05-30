using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicQueue.Data.Migrations
{
    public partial class AddColumnToTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ticket");
        }
    }
}
