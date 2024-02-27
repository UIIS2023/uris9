﻿// <auto-generated />
using System;
using JavnoNadmetanjeService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JavnoNadmetanjeService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230215181807_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.JavnoNadmetanje", b =>
                {
                    b.Property<Guid>("JavnoNadmetanjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdresaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BrojUcesnika")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("IzlicitiranaCena")
                        .HasColumnType("int");

                    b.Property<bool>("Izuzeto")
                        .HasColumnType("bit");

                    b.Property<int>("Krug")
                        .HasColumnType("int");

                    b.Property<Guid?>("KupacID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PeriodZakupa")
                        .HasColumnType("int");

                    b.Property<int>("PocetnaCenaPoHektaru")
                        .HasColumnType("int");

                    b.Property<Guid>("StatusJavnogNadmetanjaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TipJavnogNadmetanjaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("VisinaDopuneDepozita")
                        .HasColumnType("int");

                    b.Property<string>("VremeKraja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VremePocetka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JavnoNadmetanjeID");

                    b.HasIndex("StatusJavnogNadmetanjaID");

                    b.HasIndex("TipJavnogNadmetanjaID");

                    b.ToTable("JavnoNadmetanje");

                    b.HasData(
                        new
                        {
                            JavnoNadmetanjeID = new Guid("e128d9ea-25d6-47b7-8d94-4b73c6cb536c"),
                            AdresaID = new Guid("c7df55e2-9ddf-408e-9a15-9bc7e309a81f"),
                            BrojUcesnika = 10,
                            Datum = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IzlicitiranaCena = 2500,
                            Izuzeto = false,
                            Krug = 1,
                            KupacID = new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb"),
                            PeriodZakupa = 5,
                            PocetnaCenaPoHektaru = 1000,
                            StatusJavnogNadmetanjaID = new Guid("9e2d4dac-d491-46c3-a0c5-3437cb4e6cb4"),
                            TipJavnogNadmetanjaID = new Guid("b54d76e0-a230-4821-a072-e40524766d77"),
                            VisinaDopuneDepozita = 200,
                            VremeKraja = "14:00:00",
                            VremePocetka = "10:00:00"
                        },
                        new
                        {
                            JavnoNadmetanjeID = new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"),
                            AdresaID = new Guid("bab22d26-811b-4ec1-a012-025102eae6a5"),
                            BrojUcesnika = 5,
                            Datum = new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IzlicitiranaCena = 1600,
                            Izuzeto = false,
                            Krug = 2,
                            KupacID = new Guid("fead4cee-fa4c-4b6a-8b27-83b70aa43698"),
                            PeriodZakupa = 4,
                            PocetnaCenaPoHektaru = 800,
                            StatusJavnogNadmetanjaID = new Guid("9e2d4dac-d491-46c3-a0c5-3437cb4e6cb4"),
                            TipJavnogNadmetanjaID = new Guid("b54d76e0-a230-4821-a072-e40524766d77"),
                            VisinaDopuneDepozita = 300,
                            VremeKraja = "15:00:00",
                            VremePocetka = "11:00:00"
                        });
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.JavnoNadmetanjeOvlascenaLica", b =>
                {
                    b.Property<Guid>("JavnoNadmetanjeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OvlascenoLiceID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JavnoNadmetanjeID", "OvlascenoLiceID");

                    b.ToTable("JavnoNadmetanjeOvlascenaLica");

                    b.HasData(
                        new
                        {
                            JavnoNadmetanjeID = new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"),
                            OvlascenoLiceID = new Guid("87ae40cf-a971-434e-acd7-8e7f522433f9")
                        },
                        new
                        {
                            JavnoNadmetanjeID = new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"),
                            OvlascenoLiceID = new Guid("a1030c3b-9552-4946-a54e-559bed8cf733")
                        });
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.JavnoNadmetanjeParcele", b =>
                {
                    b.Property<Guid>("JavnoNadmetanjeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ParcelaID")
                        .HasColumnType("int");

                    b.HasKey("JavnoNadmetanjeID", "ParcelaID");

                    b.ToTable("JavnoNadmetanjeParcele");

                    b.HasData(
                        new
                        {
                            JavnoNadmetanjeID = new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"),
                            ParcelaID = 1
                        },
                        new
                        {
                            JavnoNadmetanjeID = new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"),
                            ParcelaID = 2
                        });
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.JavnoNadmetanjePrijavljeniKupci", b =>
                {
                    b.Property<Guid>("JavnoNadmetanjeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("KupacID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JavnoNadmetanjeID", "KupacID");

                    b.ToTable("JavnoNadmetanjePrijavljeniKupci");

                    b.HasData(
                        new
                        {
                            JavnoNadmetanjeID = new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"),
                            KupacID = new Guid("fead4cee-fa4c-4b6a-8b27-83b70aa43698")
                        },
                        new
                        {
                            JavnoNadmetanjeID = new Guid("a21d9035-cc6e-40a6-8fcc-63a3de6ae448"),
                            KupacID = new Guid("9fe2017c-8109-42d9-a7b7-9ff9e016aefb")
                        });
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.StatusJavnogNadmetanja", b =>
                {
                    b.Property<Guid>("StatusJavnogNadmetanjaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivStatusaJavnogNadmetanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusJavnogNadmetanjaID");

                    b.ToTable("StatusJavnogNadmetanja");

                    b.HasData(
                        new
                        {
                            StatusJavnogNadmetanjaID = new Guid("9e2d4dac-d491-46c3-a0c5-3437cb4e6cb4"),
                            NazivStatusaJavnogNadmetanja = "Prvi krug"
                        },
                        new
                        {
                            StatusJavnogNadmetanjaID = new Guid("bd094186-09d6-4c8e-af79-abeeee94ba8a"),
                            NazivStatusaJavnogNadmetanja = "Drugi krug sa starim uslovima"
                        });
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.TipJavnogNadmetanja", b =>
                {
                    b.Property<Guid>("TipJavnogNadmetanjaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivTipaJavnogNadmetanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipJavnogNadmetanjaID");

                    b.ToTable("TipJavnogNadmetanja");

                    b.HasData(
                        new
                        {
                            TipJavnogNadmetanjaID = new Guid("97dca59e-49df-468c-83f6-2171a966d3bb"),
                            NazivTipaJavnogNadmetanja = "Javna licitacija"
                        },
                        new
                        {
                            TipJavnogNadmetanjaID = new Guid("b54d76e0-a230-4821-a072-e40524766d77"),
                            NazivTipaJavnogNadmetanja = "Otvaranje zatvorenih ponuda"
                        });
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.JavnoNadmetanje", b =>
                {
                    b.HasOne("JavnoNadmetanjeService.Entities.StatusJavnogNadmetanja", "StatusJavnogNadmetanja")
                        .WithMany()
                        .HasForeignKey("StatusJavnogNadmetanjaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JavnoNadmetanjeService.Entities.TipJavnogNadmetanja", "TipJavnogNadmetanja")
                        .WithMany()
                        .HasForeignKey("TipJavnogNadmetanjaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusJavnogNadmetanja");

                    b.Navigation("TipJavnogNadmetanja");
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.JavnoNadmetanjeOvlascenaLica", b =>
                {
                    b.HasOne("JavnoNadmetanjeService.Entities.JavnoNadmetanje", "JavnoNadmetanje")
                        .WithMany()
                        .HasForeignKey("JavnoNadmetanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JavnoNadmetanje");
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.JavnoNadmetanjeParcele", b =>
                {
                    b.HasOne("JavnoNadmetanjeService.Entities.JavnoNadmetanje", "JavnoNadmetanje")
                        .WithMany()
                        .HasForeignKey("JavnoNadmetanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JavnoNadmetanje");
                });

            modelBuilder.Entity("JavnoNadmetanjeService.Entities.JavnoNadmetanjePrijavljeniKupci", b =>
                {
                    b.HasOne("JavnoNadmetanjeService.Entities.JavnoNadmetanje", "JavnoNadmetanje")
                        .WithMany()
                        .HasForeignKey("JavnoNadmetanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JavnoNadmetanje");
                });
#pragma warning restore 612, 618
        }
    }
}
