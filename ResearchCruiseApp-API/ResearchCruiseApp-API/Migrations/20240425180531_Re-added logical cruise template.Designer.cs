﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResearchCruiseApp_API.Data;

#nullable disable

namespace ResearchCruiseApp_API.Migrations
{
    [DbContext(typeof(ResearchCruiseContext))]
    [Migration("20240425180531_Re-added logical cruise template")]
    partial class Readdedlogicalcruisetemplate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResearchCruiseApp_API.Data.FormA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Students")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FormsA");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.LogicalCruise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FormA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LogicalCruises");
                });
#pragma warning restore 612, 618
        }
    }
}