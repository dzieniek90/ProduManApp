﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProduManApp.Data;

#nullable disable

namespace ProduManApp.Migrations
{
    [DbContext(typeof(ProduManAppDbContext))]
    [Migration("20230415224323_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProduManApp.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Order");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ProduManApp.Entities.ComplaintOrder", b =>
                {
                    b.HasBaseType("ProduManApp.Entities.Order");

                    b.HasDiscriminator().HasValue("ComplaintOrder");
                });

            modelBuilder.Entity("ProduManApp.Entities.ServiceOrder", b =>
                {
                    b.HasBaseType("ProduManApp.Entities.Order");

                    b.HasDiscriminator().HasValue("ServiceOrder");
                });
#pragma warning restore 612, 618
        }
    }
}
