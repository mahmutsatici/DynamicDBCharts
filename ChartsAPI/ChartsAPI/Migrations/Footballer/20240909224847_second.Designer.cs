﻿// <auto-generated />
using ChartsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChartsAPI.Migrations.Footballer
{
    [DbContext(typeof(FootballerContext))]
    [Migration("20240909224847_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChartsAPI.Models.Footballer", b =>
                {
                    b.Property<int>("footballerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("footballerID"), 1L, 1);

                    b.Property<string>("footballerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("totalGoal")
                        .HasColumnType("int");

                    b.HasKey("footballerID");

                    b.ToTable("Footballer");
                });
#pragma warning restore 612, 618
        }
    }
}
