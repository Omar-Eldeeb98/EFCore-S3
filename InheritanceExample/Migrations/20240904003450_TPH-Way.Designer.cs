﻿// <auto-generated />
using InheritanceExample.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InheritanceExample.Migrations
{
    [DbContext(typeof(App2Context))]
    [Migration("20240904003450_TPH-Way")]
    partial class TPHWay
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InheritanceExample.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasDiscriminator().HasValue("Employee");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("InheritanceExample.Entities.FullTimeEmployee", b =>
                {
                    b.HasBaseType("InheritanceExample.Entities.Employee");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("FullTimeEmployee");
                });

            modelBuilder.Entity("InheritanceExample.Entities.PartTimeEmployee", b =>
                {
                    b.HasBaseType("InheritanceExample.Entities.Employee");

                    b.Property<double>("HourRate")
                        .HasColumnType("float");

                    b.Property<int>("NumberOfHours")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("PartTimeEmployee");
                });
#pragma warning restore 612, 618
        }
    }
}
