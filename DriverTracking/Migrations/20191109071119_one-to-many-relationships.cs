using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DriverTracking.Migrations
{
    public partial class onetomanyrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripRecordId",
                table: "HardBreakRecords");

            migrationBuilder.DropColumn(
                name: "TripRecordId",
                table: "CitationRecords");

            migrationBuilder.DropColumn(
                name: "TripRecordId",
                table: "AccidentReportRecords");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TripRecordId",
                table: "HardBreakRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TripRecordId",
                table: "CitationRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TripRecordId",
                table: "AccidentReportRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}