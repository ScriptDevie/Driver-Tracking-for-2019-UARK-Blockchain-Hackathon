using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DriverTracking.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TotalCoins = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Departure = table.Column<DateTimeOffset>(nullable: false),
                    Arrival = table.Column<DateTimeOffset>(nullable: false),
                    MilesDriven = table.Column<double>(nullable: false),
                    WeighStationInfo = table.Column<double>(nullable: false),
                    CoinsEarned = table.Column<double>(nullable: false),
                    DriverId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripRecords_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccidentReportRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TripRecordId = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Severity = table.Column<int>(nullable: false),
                    TripRecordsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentReportRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccidentReportRecords_TripRecords_TripRecordsId",
                        column: x => x.TripRecordsId,
                        principalTable: "TripRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CitationRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TripRecordId = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    TripRecordsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitationRecords_TripRecords_TripRecordsId",
                        column: x => x.TripRecordsId,
                        principalTable: "TripRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HardBreakRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TripRecordId = table.Column<Guid>(nullable: false),
                    NumberOfHardBreaks = table.Column<int>(nullable: false),
                    TripRecordsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardBreakRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardBreakRecords_TripRecords_TripRecordsId",
                        column: x => x.TripRecordsId,
                        principalTable: "TripRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccidentReportRecords_TripRecordsId",
                table: "AccidentReportRecords",
                column: "TripRecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_CitationRecords_TripRecordsId",
                table: "CitationRecords",
                column: "TripRecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_HardBreakRecords_TripRecordsId",
                table: "HardBreakRecords",
                column: "TripRecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_TripRecords_DriverId",
                table: "TripRecords",
                column: "DriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccidentReportRecords");

            migrationBuilder.DropTable(
                name: "CitationRecords");

            migrationBuilder.DropTable(
                name: "HardBreakRecords");

            migrationBuilder.DropTable(
                name: "TripRecords");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}