﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uris.Context;

#nullable disable

namespace Uris.Migrations
{
    [DbContext(typeof(UrisDbContext))]
    [Migration("20230215172902_ChangedParcelaModel1")]
    partial class ChangedParcelaModel1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Uris.Models.KatastarskaOpstina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Okrug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KatastarskeOpstine");
                });

            modelBuilder.Entity("Uris.Models.Kultura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Kategorija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kulture");
                });

            modelBuilder.Entity("Uris.Models.KvalitetZemljista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Kvalitet")
                        .HasColumnType("int");

                    b.Property<string>("NazivVrsteZemljista")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KvalitetiZemljista");
                });

            modelBuilder.Entity("Uris.Models.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrojListaNepokretnosti")
                        .HasColumnType("int");

                    b.Property<int>("BrojParcele")
                        .HasColumnType("int");

                    b.Property<int>("KatastarskaOpstinaID")
                        .HasColumnType("int");

                    b.Property<int>("KulturaID")
                        .HasColumnType("int");

                    b.Property<Guid>("KupacId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KvalitetZemljistaID")
                        .HasColumnType("int");

                    b.Property<string>("OblikSvojine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Odvodnjavanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Povrsina")
                        .HasColumnType("real");

                    b.Property<bool>("ZasticenaZona")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Parcele");
                });
#pragma warning restore 612, 618
        }
    }
}
