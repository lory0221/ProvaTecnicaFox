﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProvaTecnicaFox.Core.Context;

#nullable disable

namespace ProvaTecnicaFox.Core.Migrations.SqlMigrations
{
    [DbContext(typeof(SqlLiteContext))]
    [Migration("20230204171726_InitialMigration_Sql")]
    partial class InitialMigration_Sql
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("ProvaTecnicaFox.Core.Models.AccomodationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PriceListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PriceListId");

                    b.ToTable("Accomodations");
                });

            modelBuilder.Entity("ProvaTecnicaFox.Core.Models.PriceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("DeluxePrice")
                        .HasColumnType("REAL");

                    b.Property<float>("DoublePrice")
                        .HasColumnType("REAL");

                    b.Property<float>("SinglePrice")
                        .HasColumnType("REAL");

                    b.Property<float>("SuitePrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("ProvaTecnicaFox.Core.Models.RoomModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccomodationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ProvaTecnicaFox.Core.Models.AccomodationModel", b =>
                {
                    b.HasOne("ProvaTecnicaFox.Core.Models.PriceModel", "PriceList")
                        .WithMany()
                        .HasForeignKey("PriceListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceList");
                });

            modelBuilder.Entity("ProvaTecnicaFox.Core.Models.RoomModel", b =>
                {
                    b.HasOne("ProvaTecnicaFox.Core.Models.AccomodationModel", "Accomodation")
                        .WithMany("Rooms")
                        .HasForeignKey("AccomodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accomodation");
                });

            modelBuilder.Entity("ProvaTecnicaFox.Core.Models.AccomodationModel", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
