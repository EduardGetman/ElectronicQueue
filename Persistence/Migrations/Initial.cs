using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicQueue.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceProvider",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NextTicketNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Letters = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ProviderId = table.Column<long>(type: "bigint", nullable: false)
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsProvided = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ProviderId = table.Column<long>(type: "bigint", nullable: false)
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ServicePointState = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ProviderId = table.Column<long>(type: "bigint", nullable: true)
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
                name: "QueueLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventKind = table.Column<int>(type: "int", nullable: false),
                    TicketKind = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    TicketName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServiceId = table.Column<long>(type: "bigint", nullable: true),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueueLog_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceStatistic",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicedClient = table.Column<int>(type: "int", nullable: false),
                    UnservicedClient = table.Column<int>(type: "int", nullable: false),
                    TotalWorkDuration = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<long>(type: "bigint", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kind = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceStatistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceStatistic_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ServiceId = table.Column<long>(type: "bigint", nullable: false),
                    QueueId = table.Column<long>(type: "bigint", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Ticket_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PointId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worker_ServicePoint_PointId",
                        column: x => x.PointId,
                        principalTable: "ServicePoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkerLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicePointName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventKind = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<long>(type: "bigint", nullable: false),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerLog_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerStatistic",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicedClient = table.Column<int>(type: "int", nullable: false),
                    TotalWorkDuration = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<long>(type: "bigint", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kind = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerStatistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerStatistic_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Queue_ProviderId",
                table: "Queue",
                column: "ProviderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QueueLog_ServiceId",
                table: "QueueLog",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ProviderId",
                table: "Service",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePoint_ProviderId",
                table: "ServicePoint",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceStatistic_ServiceId",
                table: "ServiceStatistic",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_QueueId",
                table: "Ticket",
                column: "QueueId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ServiceId",
                table: "Ticket",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_PointId",
                table: "Worker",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerLog_WorkerId",
                table: "WorkerLog",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerStatistic_WorkerId",
                table: "WorkerStatistic",
                column: "WorkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QueueLog");

            migrationBuilder.DropTable(
                name: "ServiceStatistic");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "WorkerLog");

            migrationBuilder.DropTable(
                name: "WorkerStatistic");

            migrationBuilder.DropTable(
                name: "Queue");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "ServicePoint");

            migrationBuilder.DropTable(
                name: "ServiceProvider");
        }
    }
}
