﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UgovorService.Entities;

#nullable disable

namespace UgovorService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230201122618_InitialCreate")]
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

            modelBuilder.Entity("UgovorService.Entities.Dokument", b =>
                {
                    b.Property<Guid>("DokumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumDonosenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sablon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZavodniBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DokumentID");

                    b.ToTable("Dokument");

                    b.HasData(
                        new
                        {
                            DokumentID = new Guid("20980ee8-a44e-4837-bae4-e54a9b6da870"),
                            Datum = new DateTime(2022, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            DatumDonosenja = new DateTime(2022, 4, 21, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Sablon = "Odluka o davanju u zakup poljoprivrednog zemljišta",
                            ZavodniBroj = "ABC-10"
                        },
                        new
                        {
                            DokumentID = new Guid("b11ecad0-2655-40d4-93ed-3745e2494bf8"),
                            Datum = new DateTime(2018, 6, 11, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            DatumDonosenja = new DateTime(2018, 6, 11, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            Sablon = "Odluka o poništenju odluke o davanju u zakup poljoprivrednog zemljišta",
                            ZavodniBroj = "ABC-11"
                        },
                        new
                        {
                            DokumentID = new Guid("1a397c0a-d320-4998-ae39-d137b037cbc0"),
                            Datum = new DateTime(2020, 2, 12, 13, 11, 31, 0, DateTimeKind.Unspecified),
                            DatumDonosenja = new DateTime(2020, 2, 12, 14, 20, 0, 0, DateTimeKind.Unspecified),
                            Sablon = "Odluka o raspisivanju javnog oglasa za davanje u zakup poljoprivrednog zemljišta u državnoj svojini",
                            ZavodniBroj = "ABC-12"
                        },
                        new
                        {
                            DokumentID = new Guid("8a91ab92-358b-44ae-ba1d-102639f4e738"),
                            Datum = new DateTime(2023, 1, 12, 10, 29, 0, 0, DateTimeKind.Unspecified),
                            DatumDonosenja = new DateTime(2023, 1, 12, 12, 45, 0, 0, DateTimeKind.Unspecified),
                            Sablon = "Program zaštite, uređenja i korišćenja poljopriverednog zemljišta",
                            ZavodniBroj = "ABC-13"
                        },
                        new
                        {
                            DokumentID = new Guid("364696aa-0369-4af0-954d-21b855b514e4"),
                            Datum = new DateTime(2023, 1, 16, 15, 12, 11, 0, DateTimeKind.Unspecified),
                            DatumDonosenja = new DateTime(2023, 1, 17, 12, 0, 25, 0, DateTimeKind.Unspecified),
                            Sablon = "Obrazovanje stručne komisije za pregled kvaliteta zemljišta",
                            ZavodniBroj = "DEF-20"
                        });
                });

            modelBuilder.Entity("UgovorService.Entities.TipGarancije", b =>
                {
                    b.Property<Guid>("TipGarancijeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivTipaG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipGarancijeID");

                    b.ToTable("TipGarancije");

                    b.HasData(
                        new
                        {
                            TipGarancijeID = new Guid("ea44e6b8-269c-4298-a12c-885638095e4f"),
                            NazivTipaG = "Jemstvo"
                        },
                        new
                        {
                            TipGarancijeID = new Guid("8110783f-afbe-4c01-9be7-71de8eb9deff"),
                            NazivTipaG = "Bankarska Garancija"
                        },
                        new
                        {
                            TipGarancijeID = new Guid("8973b944-d7eb-4366-8aa6-e7f9306a0304"),
                            NazivTipaG = "Garancija nekretninom"
                        },
                        new
                        {
                            TipGarancijeID = new Guid("a1885b0e-58f9-4623-92a2-f95bfe0f2fcc"),
                            NazivTipaG = "Žirantska"
                        },
                        new
                        {
                            TipGarancijeID = new Guid("85c389db-cec5-4283-bc47-a042de8785a2"),
                            NazivTipaG = "Uplata gotovinom"
                        });
                });

            modelBuilder.Entity("UgovorService.Entities.Ugovor", b =>
                {
                    b.Property<Guid>("UgovorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DatumPotpisa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZavodjenja")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DokumentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("JavnoNadmetanjeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("KupacID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MestoPotpisa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RokZaVracanjeZemljista")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TipGarancijeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZavodniBrojUgovora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UgovorID");

                    b.HasIndex("DokumentID");

                    b.HasIndex("TipGarancijeID");

                    b.ToTable("Ugovor");

                    b.HasData(
                        new
                        {
                            UgovorID = new Guid("50916085-56d4-499c-9321-ae3839c1a4f5"),
                            DatumPotpisa = new DateTime(2022, 4, 23, 14, 20, 57, 0, DateTimeKind.Unspecified),
                            DatumZavodjenja = new DateTime(2022, 1, 18, 16, 14, 33, 0, DateTimeKind.Unspecified),
                            DokumentID = new Guid("20980ee8-a44e-4837-bae4-e54a9b6da870"),
                            JavnoNadmetanjeID = new Guid("525af424-9440-4ee2-8502-01748e13f837"),
                            KupacID = new Guid("ef30d834-a569-4910-aa58-0ddedc4b669d"),
                            MestoPotpisa = "Novi Sad",
                            RokZaVracanjeZemljista = new DateTime(2025, 7, 29, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            TipGarancijeID = new Guid("ea44e6b8-269c-4298-a12c-885638095e4f"),
                            ZavodniBrojUgovora = "ugovor1"
                        });
                });

            modelBuilder.Entity("UgovorService.Entities.Ugovor", b =>
                {
                    b.HasOne("UgovorService.Entities.Dokument", "Dokument")
                        .WithMany()
                        .HasForeignKey("DokumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UgovorService.Entities.TipGarancije", "TipGarancije")
                        .WithMany()
                        .HasForeignKey("TipGarancijeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dokument");

                    b.Navigation("TipGarancije");
                });
#pragma warning restore 612, 618
        }
    }
}
