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
    [Migration("20240722204206_AddedExplicitDbSets")]
    partial class AddedExplicitDbSets
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResearchCruiseApp_API.Data.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CruiseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid?>("EvaluatedApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormCId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CruiseId");

                    b.HasIndex("EvaluatedApplicationId");

                    b.HasIndex("FormAId");

                    b.HasIndex("FormBId");

                    b.HasIndex("FormCId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<Guid?>("FormAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormCId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InstitutionLocation")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("InstitutionUnit")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<byte[]>("ScanContentCompressed")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ScanName")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("FormAId");

                    b.HasIndex("FormBId");

                    b.HasIndex("FormCId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.Cruise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MainCruiseManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MainDeputyManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cruises");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.EvaluatedApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UgTeamsPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EvaluatedApplications");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.EvaluatedContract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CalculatedPoints")
                        .HasColumnType("int");

                    b.Property<Guid>("ContractId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EvaluatedApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("EvaluatedApplicationId");

                    b.ToTable("EvaluatedContract");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.EvaluatedPublication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CalculatedPoints")
                        .HasColumnType("int");

                    b.Property<Guid?>("EvaluatedApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PublicationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EvaluatedApplicationId");

                    b.HasIndex("PublicationId");

                    b.ToTable("EvaluatedPublication");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.EvaluatedResearchTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CalculatedPoints")
                        .HasColumnType("int");

                    b.Property<Guid?>("EvaluatedApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EvaluatedApplicationId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResearchTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EvaluatedApplicationId");

                    b.HasIndex("EvaluatedApplicationId1");

                    b.HasIndex("ResearchTaskId");

                    b.ToTable("EvaluatedResearchTask");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.EvaluatedSPUBTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CalculatedPoints")
                        .HasColumnType("int");

                    b.Property<Guid?>("EvaluatedApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpubTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EvaluatedApplicationId");

                    b.HasIndex("SpubTaskId");

                    b.ToTable("EvaluatedSPUBTask");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.FormA", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AcceptablePeriodBeg")
                        .HasColumnType("int");

                    b.Property<int>("AcceptablePeriodEnd")
                        .HasColumnType("int");

                    b.Property<int>("CruiseGoal")
                        .HasColumnType("int");

                    b.Property<string>("CruiseGoalDescription")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("CruiseHours")
                        .HasColumnType("int");

                    b.Property<Guid>("CruiseManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeputyManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DifferentUsage")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("OptimalPeriodBeg")
                        .HasColumnType("int");

                    b.Property<int>("OptimalPeriodEnd")
                        .HasColumnType("int");

                    b.Property<string>("PeriodNotes")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Permissions")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("PermissionsRequired")
                        .HasColumnType("int");

                    b.Property<int>("ResearchArea")
                        .HasColumnType("int");

                    b.Property<string>("ResearchAreaInfo")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("ShipUsage")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FormsA");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.FormB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AcceptablePeriodBeg")
                        .HasColumnType("int");

                    b.Property<int>("AcceptablePeriodEnd")
                        .HasColumnType("int");

                    b.Property<int>("CruiseGoal")
                        .HasColumnType("int");

                    b.Property<string>("CruiseGoalDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CruiseHours")
                        .HasColumnType("int");

                    b.Property<Guid>("CruiseManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeputyManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OptimalPeriodBeg")
                        .HasColumnType("int");

                    b.Property<int>("OptimalPeriodEnd")
                        .HasColumnType("int");

                    b.Property<string>("PeriodNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permissions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PermissionsRequired")
                        .HasColumnType("bit");

                    b.Property<string>("ResearchArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipUsage")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FormsB");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.FormC", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AcceptablePeriodBeg")
                        .HasColumnType("int");

                    b.Property<int>("AcceptablePeriodEnd")
                        .HasColumnType("int");

                    b.Property<int>("CruiseGoal")
                        .HasColumnType("int");

                    b.Property<string>("CruiseGoalDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CruiseHours")
                        .HasColumnType("int");

                    b.Property<Guid>("CruiseManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeputyManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OptimalPeriodBeg")
                        .HasColumnType("int");

                    b.Property<int>("OptimalPeriodEnd")
                        .HasColumnType("int");

                    b.Property<string>("PeriodNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permissions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PermissionsRequired")
                        .HasColumnType("bit");

                    b.Property<string>("ResearchArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipUsage")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FormsC");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.GuestTeam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormCId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("NoOfPersons")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormAId");

                    b.HasIndex("FormBId");

                    b.HasIndex("FormCId");

                    b.ToTable("GuestTeams");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.Publication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Authors")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("DOI")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<Guid?>("FormAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormCId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Magazine")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("MinisterialPoints")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormAId");

                    b.HasIndex("FormBId");

                    b.HasIndex("FormCId");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.ResearchTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Date")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("EndDate")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<double?>("FinancingAmount")
                        .HasColumnType("float");

                    b.Property<Guid?>("FormAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormCId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Institution")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("StartDate")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Title")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormAId");

                    b.HasIndex("FormBId");

                    b.HasIndex("FormCId");

                    b.ToTable("ResearchTasks");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.SPUBTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormCId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("YearFrom")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("YearTo")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("FormAId");

                    b.HasIndex("FormBId");

                    b.HasIndex("FormCId");

                    b.ToTable("SPUBTasks");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.Thesis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<Guid?>("FormAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormCId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Promoter")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormAId");

                    b.HasIndex("FormBId");

                    b.HasIndex("FormCId");

                    b.ToTable("Theses");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.UGTeam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormBId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FormCId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NoOfEmployees")
                        .HasColumnType("int");

                    b.Property<int>("NoOfStudents")
                        .HasColumnType("int");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormAId");

                    b.HasIndex("FormBId");

                    b.HasIndex("FormCId");

                    b.ToTable("UgTeams");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.Application", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.Cruise", null)
                        .WithMany("Applications")
                        .HasForeignKey("CruiseId");

                    b.HasOne("ResearchCruiseApp_API.Data.EvaluatedApplication", "EvaluatedApplication")
                        .WithMany()
                        .HasForeignKey("EvaluatedApplicationId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormA", "FormA")
                        .WithMany()
                        .HasForeignKey("FormAId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormB", "FormB")
                        .WithMany()
                        .HasForeignKey("FormBId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormC", "FormC")
                        .WithMany()
                        .HasForeignKey("FormCId");

                    b.Navigation("EvaluatedApplication");

                    b.Navigation("FormA");

                    b.Navigation("FormB");

                    b.Navigation("FormC");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.Contract", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.FormA", null)
                        .WithMany("Contracts")
                        .HasForeignKey("FormAId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormB", null)
                        .WithMany("Contracts")
                        .HasForeignKey("FormBId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormC", null)
                        .WithMany("Contracts")
                        .HasForeignKey("FormCId");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.EvaluatedContract", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResearchCruiseApp_API.Data.EvaluatedApplication", null)
                        .WithMany("Contracts")
                        .HasForeignKey("EvaluatedApplicationId");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.EvaluatedPublication", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.EvaluatedApplication", null)
                        .WithMany("Publications")
                        .HasForeignKey("EvaluatedApplicationId");

                    b.HasOne("ResearchCruiseApp_API.Data.Publication", "Publication")
                        .WithMany()
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.EvaluatedResearchTask", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.EvaluatedApplication", null)
                        .WithMany("CruiseEffects")
                        .HasForeignKey("EvaluatedApplicationId");

                    b.HasOne("ResearchCruiseApp_API.Data.EvaluatedApplication", null)
                        .WithMany("ResearchTasks")
                        .HasForeignKey("EvaluatedApplicationId1");

                    b.HasOne("ResearchCruiseApp_API.Data.ResearchTask", "ResearchTask")
                        .WithMany()
                        .HasForeignKey("ResearchTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResearchTask");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.EvaluatedSPUBTask", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.EvaluatedApplication", null)
                        .WithMany("SpubTasks")
                        .HasForeignKey("EvaluatedApplicationId");

                    b.HasOne("ResearchCruiseApp_API.Data.SPUBTask", "SpubTask")
                        .WithMany()
                        .HasForeignKey("SpubTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpubTask");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.GuestTeam", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.FormA", null)
                        .WithMany("GuestTeams")
                        .HasForeignKey("FormAId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormB", null)
                        .WithMany("GuestTeams")
                        .HasForeignKey("FormBId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormC", null)
                        .WithMany("GuestTeams")
                        .HasForeignKey("FormCId");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.Publication", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.FormA", null)
                        .WithMany("Publications")
                        .HasForeignKey("FormAId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormB", null)
                        .WithMany("Publications")
                        .HasForeignKey("FormBId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormC", null)
                        .WithMany("Publications")
                        .HasForeignKey("FormCId");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.ResearchTask", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.FormA", null)
                        .WithMany("ResearchTasks")
                        .HasForeignKey("FormAId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormB", null)
                        .WithMany("ResearchTasks")
                        .HasForeignKey("FormBId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormC", null)
                        .WithMany("ResearchTasks")
                        .HasForeignKey("FormCId");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.SPUBTask", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.FormA", null)
                        .WithMany("SPUBTasks")
                        .HasForeignKey("FormAId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormB", null)
                        .WithMany("SPUBTasks")
                        .HasForeignKey("FormBId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormC", null)
                        .WithMany("SPUBTasks")
                        .HasForeignKey("FormCId");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.Thesis", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.FormA", null)
                        .WithMany("Theses")
                        .HasForeignKey("FormAId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormB", null)
                        .WithMany("Theses")
                        .HasForeignKey("FormBId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormC", null)
                        .WithMany("Theses")
                        .HasForeignKey("FormCId");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.UGTeam", b =>
                {
                    b.HasOne("ResearchCruiseApp_API.Data.FormA", null)
                        .WithMany("UGTeams")
                        .HasForeignKey("FormAId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormB", null)
                        .WithMany("UGTeams")
                        .HasForeignKey("FormBId");

                    b.HasOne("ResearchCruiseApp_API.Data.FormC", null)
                        .WithMany("UGTeams")
                        .HasForeignKey("FormCId");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.Cruise", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.EvaluatedApplication", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("CruiseEffects");

                    b.Navigation("Publications");

                    b.Navigation("ResearchTasks");

                    b.Navigation("SpubTasks");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.FormA", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("GuestTeams");

                    b.Navigation("Publications");

                    b.Navigation("ResearchTasks");

                    b.Navigation("SPUBTasks");

                    b.Navigation("Theses");

                    b.Navigation("UGTeams");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.FormB", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("GuestTeams");

                    b.Navigation("Publications");

                    b.Navigation("ResearchTasks");

                    b.Navigation("SPUBTasks");

                    b.Navigation("Theses");

                    b.Navigation("UGTeams");
                });

            modelBuilder.Entity("ResearchCruiseApp_API.Data.FormC", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("GuestTeams");

                    b.Navigation("Publications");

                    b.Navigation("ResearchTasks");

                    b.Navigation("SPUBTasks");

                    b.Navigation("Theses");

                    b.Navigation("UGTeams");
                });
#pragma warning restore 612, 618
        }
    }
}
