﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WirVsVirus.Database;

namespace WirVsVirus.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200322103749_Mig_2")]
    partial class Mig_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WirVsVirus.Domain.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("WirVsVirus.Domain.Models.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<bool>("BarrierFree")
                        .HasColumnType("bit");

                    b.Property<int>("Beds")
                        .HasColumnType("int");

                    b.Property<bool>("HeavyCurrent")
                        .HasColumnType("bit");

                    b.Property<double>("HeavyCurrentCapacity")
                        .HasColumnType("float");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityWaterConnections")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("Gyms");
                });

            modelBuilder.Entity("WirVsVirus.Domain.Models.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BarrierFree")
                        .HasColumnType("bit");

                    b.Property<int>("BedsWithVentilator")
                        .HasColumnType("int");

                    b.Property<int>("BedsWithoutVentilator")
                        .HasColumnType("int");

                    b.Property<string>("IkId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmergencyHospital")
                        .HasColumnType("bit");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("WirVsVirus.Domain.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BedsWithVentilatorOtherFLoor")
                        .HasColumnType("int");

                    b.Property<int>("BedsWithVentilatorWithCarpet")
                        .HasColumnType("int");

                    b.Property<int>("BedsWithoutVentilatorWithCarpet")
                        .HasColumnType("int");

                    b.Property<string>("FireProtectionsRegulations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HeavyCurentCapacity")
                        .HasColumnType("float");

                    b.Property<bool>("HeavyCurrent")
                        .HasColumnType("bit");

                    b.Property<int>("KitchenCapacity")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("WirVsVirus.Domain.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AccessToInternet")
                        .HasColumnType("bit");

                    b.Property<string>("Accessability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactInfoId")
                        .HasColumnType("int");

                    b.Property<string>("GeoLatitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeoLongitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<int>("PostCode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactInfoId")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WirVsVirus.Domain.Models.SanitaryInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BarrierFree")
                        .HasColumnType("bit");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityBathrooms")
                        .HasColumnType("int");

                    b.Property<int>("QuantityShowers")
                        .HasColumnType("int");

                    b.Property<int>("QuantitySinks")
                        .HasColumnType("int");

                    b.Property<int>("QuantityToilents")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("SanitaryInfos");
                });

            modelBuilder.Entity("WirVsVirus.Domain.Models.Gym", b =>
                {
                    b.HasOne("WirVsVirus.Domain.Models.Location", "Location")
                        .WithOne("Gym")
                        .HasForeignKey("WirVsVirus.Domain.Models.Gym", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WirVsVirus.Domain.Models.Hospital", b =>
                {
                    b.HasOne("WirVsVirus.Domain.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WirVsVirus.Domain.Models.Hotel", b =>
                {
                    b.HasOne("WirVsVirus.Domain.Models.Location", "Location")
                        .WithOne("Hotel")
                        .HasForeignKey("WirVsVirus.Domain.Models.Hotel", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WirVsVirus.Domain.Models.Location", b =>
                {
                    b.HasOne("WirVsVirus.Domain.Models.ContactInfo", "ContactInfo")
                        .WithOne("Location")
                        .HasForeignKey("WirVsVirus.Domain.Models.Location", "ContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WirVsVirus.Domain.Models.SanitaryInfo", b =>
                {
                    b.HasOne("WirVsVirus.Domain.Models.Location", "Location")
                        .WithOne("SanitaryInfo")
                        .HasForeignKey("WirVsVirus.Domain.Models.SanitaryInfo", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
