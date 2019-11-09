﻿// <auto-generated />
using System;
using DriverTracking.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DriverTracking.Migrations
{
    [DbContext(typeof(DriverTrackingContext))]
    [Migration("20191109065308_relationships")]
    partial class relationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DriverTracking.Entities.AccidentReportRecords", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Severity")
                        .HasColumnType("int");

                    b.Property<Guid>("TripRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TripRecordsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TripRecordsId");

                    b.ToTable("AccidentReportRecords");
                });

            modelBuilder.Entity("DriverTracking.Entities.CitationRecords", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TripRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TripRecordsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TripRecordsId");

                    b.ToTable("CitationRecords");
                });

            modelBuilder.Entity("DriverTracking.Entities.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalCoins")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("DriverTracking.Entities.HardBreakRecords", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfHardBreaks")
                        .HasColumnType("int");

                    b.Property<Guid>("TripRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TripRecordsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TripRecordsId");

                    b.ToTable("HardBreakRecords");
                });

            modelBuilder.Entity("DriverTracking.Entities.TripRecords", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Arrival")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("CoinsEarned")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("Departure")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("MilesDriven")
                        .HasColumnType("float");

                    b.Property<double>("WeighStationInfo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("TripRecords");
                });

            modelBuilder.Entity("DriverTracking.Entities.AccidentReportRecords", b =>
                {
                    b.HasOne("DriverTracking.Entities.TripRecords", null)
                        .WithMany("Accidents")
                        .HasForeignKey("TripRecordsId");
                });

            modelBuilder.Entity("DriverTracking.Entities.CitationRecords", b =>
                {
                    b.HasOne("DriverTracking.Entities.TripRecords", null)
                        .WithMany("Citations")
                        .HasForeignKey("TripRecordsId");
                });

            modelBuilder.Entity("DriverTracking.Entities.HardBreakRecords", b =>
                {
                    b.HasOne("DriverTracking.Entities.TripRecords", null)
                        .WithMany("HardBreaks")
                        .HasForeignKey("TripRecordsId");
                });

            modelBuilder.Entity("DriverTracking.Entities.TripRecords", b =>
                {
                    b.HasOne("DriverTracking.Entities.Driver", "Driver")
                        .WithMany("TripRecords")
                        .HasForeignKey("DriverId");
                });
#pragma warning restore 612, 618
        }
    }
}
