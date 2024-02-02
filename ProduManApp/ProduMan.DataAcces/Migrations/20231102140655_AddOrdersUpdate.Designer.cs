﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProduMan.DataAccess;

#nullable disable

namespace ProduMan.DataAccess.Migrations
{
    [DbContext(typeof(ProduManContext))]
    [Migration("20231102140655_AddOrdersUpdate")]
    partial class AddOrdersUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProduMan.DataAccess.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AOI")
                        .HasColumnType("bit");

                    b.Property<string>("Deadline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DzienTygodnia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IloscDoZmontowania")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Komponenty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lp")
                        .HasColumnType("int");

                    b.Property<bool>("Mycie")
                        .HasColumnType("bit");

                    b.Property<string>("NowyProdukt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrZamowienia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OsobaPrzyjmujacaZlecenie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poziom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Programowanie")
                        .HasColumnType("bit");

                    b.Property<string>("SMD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("THT")
                        .HasColumnType("bit");

                    b.Property<string>("Temat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Testowanie")
                        .HasColumnType("bit");

                    b.Property<string>("Traceability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tydzien")
                        .HasColumnType("int");

                    b.Property<string>("Uwagi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UwagiSmd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UwagiSzablon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UwagiTht")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZamowionaIlosc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZmontowanaIlosc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProduMan.DataAccess.Entities.ProductionBatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerOrderNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductionBatches");
                });

            modelBuilder.Entity("ProduMan.DataAccess.Entities.ReleaseDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductionBatchId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductionBatchId");

                    b.ToTable("ReleaseDates");
                });

            modelBuilder.Entity("ProduMan.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProduMan.DataAccess.Entities.ReleaseDate", b =>
                {
                    b.HasOne("ProduMan.DataAccess.Entities.ProductionBatch", "ProductionBatch")
                        .WithMany("ReleaseDates")
                        .HasForeignKey("ProductionBatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductionBatch");
                });

            modelBuilder.Entity("ProduMan.DataAccess.Entities.ProductionBatch", b =>
                {
                    b.Navigation("ReleaseDates");
                });
#pragma warning restore 612, 618
        }
    }
}