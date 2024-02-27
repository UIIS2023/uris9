﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mikroservis_Uplata.Context;

#nullable disable

namespace MikroservisUplata.Migrations
{
    [DbContext(typeof(UrisDbContext))]
    [Migration("20230203091510_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mikroservis_Uplata.Models.Kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Valuta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kursevi");
                });

            modelBuilder.Entity("Mikroservis_Uplata.Models.Uplata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrojRacuna")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Iznos")
                        .HasColumnType("int");

                    b.Property<int>("KursID")
                        .HasColumnType("int");

                    b.Property<string>("PozivNaBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SvrhaUplate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KursID");

                    b.ToTable("Uplate");
                });

            modelBuilder.Entity("Mikroservis_Uplata.Models.Uplata", b =>
                {
                    b.HasOne("Mikroservis_Uplata.Models.Kurs", "Kurs")
                        .WithMany()
                        .HasForeignKey("KursID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kurs");
                });
#pragma warning restore 612, 618
        }
    }
}
