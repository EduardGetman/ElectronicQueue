using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ElectronicQueue.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceProvider",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Queue",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Letters = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    NumberLastTickets = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ProviderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queue_ServiceProvider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "ServiceProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsProvided = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ProviderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_ServiceProvider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "ServiceProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePoint",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ServicePointState = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ProviderId = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePoint_ServiceProvider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "ServiceProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TimeUpdatedState = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QueueId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Queue_QueueId",
                        column: x => x.QueueId,
                        principalTable: "Queue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Queue_ProviderId",
                table: "Queue",
                column: "ProviderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_ProviderId",
                table: "Service",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePoint_ProviderId",
                table: "ServicePoint",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_QueueId",
                table: "Ticket",
                column: "QueueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "ServicePoint");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Queue");

            migrationBuilder.DropTable(
                name: "ServiceProvider");
        }
    }
}
