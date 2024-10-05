using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFormBEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_FormsB_FormBId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_FormAGuestUnits_FormsB_FormBId",
                table: "FormAGuestUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_FormAUgUnits_FormsB_FormBId",
                table: "FormAUgUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_FormsB_FormBId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_ResearchTasks_FormsB_FormBId",
                table: "ResearchTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_SpubTasks_FormsB_FormBId",
                table: "SpubTasks");

            migrationBuilder.DropIndex(
                name: "IX_SpubTasks_FormBId",
                table: "SpubTasks");

            migrationBuilder.DropIndex(
                name: "IX_ResearchTasks_FormBId",
                table: "ResearchTasks");

            migrationBuilder.DropIndex(
                name: "IX_Publications_FormBId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_FormAUgUnits_FormBId",
                table: "FormAUgUnits");

            migrationBuilder.DropIndex(
                name: "IX_FormAGuestUnits_FormBId",
                table: "FormAGuestUnits");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_FormBId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "FormBId",
                table: "SpubTasks");

            migrationBuilder.DropColumn(
                name: "FormBId",
                table: "ResearchTasks");

            migrationBuilder.DropColumn(
                name: "FormBId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "AcceptablePeriodBeg",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "AcceptablePeriodEnd",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "CruiseGoal",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "CruiseGoalDescription",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "CruiseHours",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "CruiseManagerId",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "DeputyManagerId",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "OptimalPeriodBeg",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "OptimalPeriodEnd",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "PeriodNotes",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "PermissionsRequired",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "ResearchArea",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "ShipUsage",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "FormBId",
                table: "FormAUgUnits");

            migrationBuilder.DropColumn(
                name: "FormBId",
                table: "FormAGuestUnits");

            migrationBuilder.DropColumn(
                name: "FormBId",
                table: "Contracts");

            migrationBuilder.AddColumn<Guid>(
                name: "FormBId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CruiseManagerPresent",
                table: "FormsB",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CrewMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    DocumentExpiryDate = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CruiseDaysDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Hours = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    FormBId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CruiseDaysDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CruiseDaysDetails_FormsB_FormBId",
                        column: x => x.FormBId,
                        principalTable: "FormsB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormBGuestUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoOfPersons = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBGuestUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormBGuestUnits_FormsB_FormBId",
                        column: x => x.FormBId,
                        principalTable: "FormsB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormBGuestUnits_GuestUnits_GuestUnitId",
                        column: x => x.GuestUnitId,
                        principalTable: "GuestUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormBUgUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UgUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoOfEmployees = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    NoOfStudents = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBUgUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormBUgUnits_FormsB_FormBId",
                        column: x => x.FormBId,
                        principalTable: "FormsB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormBUgUnits_UgUnits_UgUnitId",
                        column: x => x.UgUnitId,
                        principalTable: "UgUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchEquipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FormBId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipEquipments_FormsB_FormBId",
                        column: x => x.FormBId,
                        principalTable: "FormsB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CrewMemberFormB",
                columns: table => new
                {
                    CrewMembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormsBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMemberFormB", x => new { x.CrewMembersId, x.FormsBId });
                    table.ForeignKey(
                        name: "FK_CrewMemberFormB_CrewMembers_CrewMembersId",
                        column: x => x.CrewMembersId,
                        principalTable: "CrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrewMemberFormB_FormsB_FormsBId",
                        column: x => x.FormsBId,
                        principalTable: "FormsB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormBPorts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBPorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormBPorts_FormsB_FormBId",
                        column: x => x.FormBId,
                        principalTable: "FormsB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormBPorts_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormBLongResearchEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchEquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBLongResearchEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormBLongResearchEquipments_FormsB_FormBId",
                        column: x => x.FormBId,
                        principalTable: "FormsB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormBLongResearchEquipments_ResearchEquipments_ResearchEquipmentId",
                        column: x => x.ResearchEquipmentId,
                        principalTable: "ResearchEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormBResearchEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchEquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBResearchEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormBResearchEquipments_FormsB_FormBId",
                        column: x => x.FormBId,
                        principalTable: "FormsB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormBResearchEquipments_ResearchEquipments_ResearchEquipmentId",
                        column: x => x.ResearchEquipmentId,
                        principalTable: "ResearchEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormBShortResearchEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchEquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBShortResearchEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormBShortResearchEquipments_FormsB_FormBId",
                        column: x => x.FormBId,
                        principalTable: "FormsB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormBShortResearchEquipments_ResearchEquipments_ResearchEquipmentId",
                        column: x => x.ResearchEquipmentId,
                        principalTable: "ResearchEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_FormBId",
                table: "Permissions",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMemberFormB_FormsBId",
                table: "CrewMemberFormB",
                column: "FormsBId");

            migrationBuilder.CreateIndex(
                name: "IX_CruiseDaysDetails_FormBId",
                table: "CruiseDaysDetails",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBGuestUnits_FormBId",
                table: "FormBGuestUnits",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBGuestUnits_GuestUnitId",
                table: "FormBGuestUnits",
                column: "GuestUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBLongResearchEquipments_FormBId",
                table: "FormBLongResearchEquipments",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBLongResearchEquipments_ResearchEquipmentId",
                table: "FormBLongResearchEquipments",
                column: "ResearchEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBPorts_FormBId",
                table: "FormBPorts",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBPorts_PortId",
                table: "FormBPorts",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBResearchEquipments_FormBId",
                table: "FormBResearchEquipments",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBResearchEquipments_ResearchEquipmentId",
                table: "FormBResearchEquipments",
                column: "ResearchEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBShortResearchEquipments_FormBId",
                table: "FormBShortResearchEquipments",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBShortResearchEquipments_ResearchEquipmentId",
                table: "FormBShortResearchEquipments",
                column: "ResearchEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBUgUnits_FormBId",
                table: "FormBUgUnits",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_FormBUgUnits_UgUnitId",
                table: "FormBUgUnits",
                column: "UgUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipEquipments_FormBId",
                table: "ShipEquipments",
                column: "FormBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_FormsB_FormBId",
                table: "Permissions",
                column: "FormBId",
                principalTable: "FormsB",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_FormsB_FormBId",
                table: "Permissions");

            migrationBuilder.DropTable(
                name: "CrewMemberFormB");

            migrationBuilder.DropTable(
                name: "CruiseDaysDetails");

            migrationBuilder.DropTable(
                name: "FormBGuestUnits");

            migrationBuilder.DropTable(
                name: "FormBLongResearchEquipments");

            migrationBuilder.DropTable(
                name: "FormBPorts");

            migrationBuilder.DropTable(
                name: "FormBResearchEquipments");

            migrationBuilder.DropTable(
                name: "FormBShortResearchEquipments");

            migrationBuilder.DropTable(
                name: "FormBUgUnits");

            migrationBuilder.DropTable(
                name: "ShipEquipments");

            migrationBuilder.DropTable(
                name: "CrewMembers");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "ResearchEquipments");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_FormBId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "FormBId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CruiseManagerPresent",
                table: "FormsB");

            migrationBuilder.AddColumn<Guid>(
                name: "FormBId",
                table: "SpubTasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormBId",
                table: "ResearchTasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormBId",
                table: "Publications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcceptablePeriodBeg",
                table: "FormsB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcceptablePeriodEnd",
                table: "FormsB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CruiseGoal",
                table: "FormsB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CruiseGoalDescription",
                table: "FormsB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CruiseHours",
                table: "FormsB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CruiseManagerId",
                table: "FormsB",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeputyManagerId",
                table: "FormsB",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "OptimalPeriodBeg",
                table: "FormsB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OptimalPeriodEnd",
                table: "FormsB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PeriodNotes",
                table: "FormsB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Permissions",
                table: "FormsB",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PermissionsRequired",
                table: "FormsB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ResearchArea",
                table: "FormsB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShipUsage",
                table: "FormsB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "FormsB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "FormBId",
                table: "FormAUgUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormBId",
                table: "FormAGuestUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormBId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpubTasks_FormBId",
                table: "SpubTasks",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchTasks_FormBId",
                table: "ResearchTasks",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_FormBId",
                table: "Publications",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAUgUnits_FormBId",
                table: "FormAUgUnits",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAGuestUnits_FormBId",
                table: "FormAGuestUnits",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FormBId",
                table: "Contracts",
                column: "FormBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_FormsB_FormBId",
                table: "Contracts",
                column: "FormBId",
                principalTable: "FormsB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormAGuestUnits_FormsB_FormBId",
                table: "FormAGuestUnits",
                column: "FormBId",
                principalTable: "FormsB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormAUgUnits_FormsB_FormBId",
                table: "FormAUgUnits",
                column: "FormBId",
                principalTable: "FormsB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_FormsB_FormBId",
                table: "Publications",
                column: "FormBId",
                principalTable: "FormsB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchTasks_FormsB_FormBId",
                table: "ResearchTasks",
                column: "FormBId",
                principalTable: "FormsB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpubTasks_FormsB_FormBId",
                table: "SpubTasks",
                column: "FormBId",
                principalTable: "FormsB",
                principalColumn: "Id");
        }
    }
}
