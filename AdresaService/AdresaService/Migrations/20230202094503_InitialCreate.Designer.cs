﻿// <auto-generated />
using System;
using AdresaService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdresaService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230202094503_InitialCreate")]
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

            modelBuilder.Entity("AdresaService.Entities.Adresa", b =>
                {
                    b.Property<Guid>("AdresaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Broj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DrzavaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdresaID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Adresa");

                    b.HasData(
                        new
                        {
                            AdresaID = new Guid("c7df55e2-9ddf-408e-9a15-9bc7e309a81f"),
                            Broj = "9",
                            DrzavaID = new Guid("96bac703-7677-4db3-858c-22b38f34dc19"),
                            Mesto = "Novi Sad",
                            PostanskiBroj = "21000",
                            Ulica = "Save Kovacevica"
                        },
                        new
                        {
                            AdresaID = new Guid("bab22d26-811b-4ec1-a012-025102eae6a5"),
                            Broj = "19",
                            DrzavaID = new Guid("61fa9534-5c22-41fd-9517-b0de7eaed1e0"),
                            Mesto = "Podgorica",
                            PostanskiBroj = "22000",
                            Ulica = "Jove Pantica"
                        },
                        new
                        {
                            AdresaID = new Guid("18867358-9ff9-4694-8da9-7719ecad7a51"),
                            Broj = "4",
                            DrzavaID = new Guid("0c520e55-4f91-44e4-a647-7ed01e758663"),
                            Mesto = "Split",
                            PostanskiBroj = "23000",
                            Ulica = "Mike Antica"
                        });
                });

            modelBuilder.Entity("AdresaService.Entities.Drzava", b =>
                {
                    b.Property<Guid>("DrzavaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NazivDrzave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrzavaID");

                    b.ToTable("Drzava");

                    b.HasData(
                        new
                        {
                            DrzavaID = new Guid("96bac703-7677-4db3-858c-22b38f34dc19"),
                            NazivDrzave = "Srbija"
                        },
                        new
                        {
                            DrzavaID = new Guid("61fa9534-5c22-41fd-9517-b0de7eaed1e0"),
                            NazivDrzave = "Crna Gora"
                        },
                        new
                        {
                            DrzavaID = new Guid("f662cca3-ac7d-42b4-a4a2-97be06d0ca2a"),
                            NazivDrzave = "Madjarska"
                        },
                        new
                        {
                            DrzavaID = new Guid("0c520e55-4f91-44e4-a647-7ed01e758663"),
                            NazivDrzave = "Hrvatska"
                        },
                        new
                        {
                            DrzavaID = new Guid("24140a35-74e6-4201-8795-219b89b336d5"),
                            NazivDrzave = "Rumunija"
                        });
                });

            modelBuilder.Entity("AdresaService.Entities.Adresa", b =>
                {
                    b.HasOne("AdresaService.Entities.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drzava");
                });
#pragma warning restore 612, 618
        }
    }
}
