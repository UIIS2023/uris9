﻿// <auto-generated />
using KomisijaURIS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KomisijaURIS.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230203184432_AddKomisijaTable")]
    partial class AddKomisijaTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KomisijaURIS.Entites.ClanKomisije", b =>
                {
                    b.Property<int>("ClanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClanId"));

                    b.Property<string>("EmailClana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeClana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrezimeClana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClanId");

                    b.ToTable("ClanoviKomisije");
                });

            modelBuilder.Entity("KomisijaURIS.Entites.Komisija", b =>
                {
                    b.Property<int>("KomisijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KomisijaId"));

                    b.Property<int>("ClanId")
                        .HasColumnType("int");

                    b.Property<int>("PredsednikId")
                        .HasColumnType("int");

                    b.HasKey("KomisijaId");

                    b.HasIndex("ClanId");

                    b.HasIndex("PredsednikId");

                    b.ToTable("Komisije");
                });

            modelBuilder.Entity("KomisijaURIS.Entites.Predsednik", b =>
                {
                    b.Property<int>("PredsednikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PredsednikId"));

                    b.Property<string>("EmailPredsednika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImePredsednika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrezimePredsednika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PredsednikId");

                    b.ToTable("Predsednici");
                });

            modelBuilder.Entity("KomisijaURIS.Entites.Komisija", b =>
                {
                    b.HasOne("KomisijaURIS.Entites.ClanKomisije", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KomisijaURIS.Entites.Predsednik", "Predsednik")
                        .WithMany()
                        .HasForeignKey("PredsednikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clan");

                    b.Navigation("Predsednik");
                });
#pragma warning restore 612, 618
        }
    }
}
