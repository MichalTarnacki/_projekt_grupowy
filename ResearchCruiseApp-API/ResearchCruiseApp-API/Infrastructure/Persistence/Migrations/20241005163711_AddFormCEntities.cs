using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFormCEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormAGuestUnits_FormsC_FormCId",
                table: "FormAGuestUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_FormAUgUnits_FormsC_FormCId",
                table: "FormAUgUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_FormsC_FormCId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_ResearchTasks_FormsC_FormCId",
                table: "ResearchTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_SpubTasks_FormsC_FormCId",
                table: "SpubTasks");

            migrationBuilder.DropIndex(
                name: "IX_SpubTasks_FormCId",
                table: "SpubTasks");

            migrationBuilder.DropIndex(
                name: "IX_ResearchTasks_FormCId",
                table: "ResearchTasks");

            migrationBuilder.DropIndex(
                name: "IX_Publications_FormCId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_FormAUgUnits_FormCId",
                table: "FormAUgUnits");

            migrationBuilder.DropIndex(
                name: "IX_FormAGuestUnits_FormCId",
                table: "FormAGuestUnits");

            migrationBuilder.DropColumn(
                name: "FormCId",
                table: "SpubTasks");

            migrationBuilder.DropColumn(
                name: "FormCId",
                table: "ResearchTasks");

            migrationBuilder.DropColumn(
                name: "FormCId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "AcceptablePeriodBeg",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "AcceptablePeriodEnd",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "CruiseGoal",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "CruiseGoalDescription",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "CruiseHours",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "CruiseManagerId",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "OptimalPeriodBeg",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "OptimalPeriodEnd",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "PeriodNotes",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "PermissionsRequired",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "ResearchArea",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "FormCId",
                table: "FormAUgUnits");

            migrationBuilder.DropColumn(
                name: "FormCId",
                table: "FormAGuestUnits");

            migrationBuilder.RenameColumn(
                name: "DeputyManagerId",
                table: "FormsC",
                newName: "ResearchAreaId");

            migrationBuilder.AddColumn<Guid>(
                name: "FormCId",
                table: "ShipEquipments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormCId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShipUsage",
                table: "FormsC",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalDescription",
                table: "FormsC",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalSpubData",
                table: "FormsC",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ResearchAreaId",
                table: "FormsB",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "FormBShortResearchEquipments",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "FormBShortResearchEquipments",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Permission",
                table: "FormBResearchEquipments",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Insurance",
                table: "FormBResearchEquipments",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "FormCId",
                table: "CruiseDaysDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CollectedSamples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Analysis = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Publishing = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    FormCId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectedSamples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectedSamples_FormsC_FormCId",
                        column: x => x.FormCId,
                        principalTable: "FormsC",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormCLongResearchEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchEquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCLongResearchEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormCLongResearchEquipments_FormsC_FormCId",
                        column: x => x.FormCId,
                        principalTable: "FormsC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormCLongResearchEquipments_ResearchEquipments_ResearchEquipmentId",
                        column: x => x.ResearchEquipmentId,
                        principalTable: "ResearchEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormCPorts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCPorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormCPorts_FormsC_FormCId",
                        column: x => x.FormCId,
                        principalTable: "FormsC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormCPorts_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormCResearchEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchEquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Insurance = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Permission = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCResearchEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormCResearchEquipments_FormsC_FormCId",
                        column: x => x.FormCId,
                        principalTable: "FormsC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormCResearchEquipments_ResearchEquipments_ResearchEquipmentId",
                        column: x => x.ResearchEquipmentId,
                        principalTable: "ResearchEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormCResearchTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Done = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ManagerConditionMet = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    DeputyConditionMet = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCResearchTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormCResearchTasks_FormsC_FormCId",
                        column: x => x.FormCId,
                        principalTable: "FormsC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormCResearchTasks_ResearchTasks_ResearchTaskId",
                        column: x => x.ResearchTaskId,
                        principalTable: "ResearchTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormCShortResearchEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchEquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCShortResearchEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormCShortResearchEquipments_FormsC_FormCId",
                        column: x => x.FormCId,
                        principalTable: "FormsC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormCShortResearchEquipments_ResearchEquipments_ResearchEquipmentId",
                        column: x => x.ResearchEquipmentId,
                        principalTable: "ResearchEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormCSpubTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpubTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCSpubTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormCSpubTasks_FormsC_FormCId",
                        column: x => x.FormCId,
                        principalTable: "FormsC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormCSpubTasks_SpubTasks_SpubTaskId",
                        column: x => x.SpubTaskId,
                        principalTable: "SpubTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormCUgUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UgUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoOfEmployees = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    NoOfStudents = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCUgUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormCUgUnits_FormsC_FormCId",
                        column: x => x.FormCId,
                        principalTable: "FormsC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormCUgUnits_UgUnits_UgUnitId",
                        column: x => x.UgUnitId,
                        principalTable: "UgUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormGuestUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoOfPersons = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormGuestUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormGuestUnits_FormsC_FormCId",
                        column: x => x.FormCId,
                        principalTable: "FormsC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormGuestUnits_GuestUnits_GuestUnitId",
                        column: x => x.GuestUnitId,
                        principalTable: "GuestUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CruiseApplicationEffects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CruiseApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CruiseApplicationEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CruiseApplicationEffects_CruiseApplications_CruiseApplicationId",
                        column: x => x.CruiseApplicationId,
                        principalTable: "CruiseApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CruiseApplicationEffects_FormCResearchTasks_EffectId",
                        column: x => x.EffectId,
                        principalTable: "FormCResearchTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipEquipments_FormCId",
                table: "ShipEquipments",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_FormCId",
                table: "Permissions",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormsC_ResearchAreaId",
                table: "FormsC",
                column: "ResearchAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_FormsB_ResearchAreaId",
                table: "FormsB",
                column: "ResearchAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CruiseDaysDetails_FormCId",
                table: "CruiseDaysDetails",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectedSamples_FormCId",
                table: "CollectedSamples",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_CruiseApplicationEffects_CruiseApplicationId",
                table: "CruiseApplicationEffects",
                column: "CruiseApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_CruiseApplicationEffects_EffectId",
                table: "CruiseApplicationEffects",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCLongResearchEquipments_FormCId",
                table: "FormCLongResearchEquipments",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCLongResearchEquipments_ResearchEquipmentId",
                table: "FormCLongResearchEquipments",
                column: "ResearchEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCPorts_FormCId",
                table: "FormCPorts",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCPorts_PortId",
                table: "FormCPorts",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCResearchEquipments_FormCId",
                table: "FormCResearchEquipments",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCResearchEquipments_ResearchEquipmentId",
                table: "FormCResearchEquipments",
                column: "ResearchEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCResearchTasks_FormCId",
                table: "FormCResearchTasks",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCResearchTasks_ResearchTaskId",
                table: "FormCResearchTasks",
                column: "ResearchTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCShortResearchEquipments_FormCId",
                table: "FormCShortResearchEquipments",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCShortResearchEquipments_ResearchEquipmentId",
                table: "FormCShortResearchEquipments",
                column: "ResearchEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCSpubTasks_FormCId",
                table: "FormCSpubTasks",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCSpubTasks_SpubTaskId",
                table: "FormCSpubTasks",
                column: "SpubTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCUgUnits_FormCId",
                table: "FormCUgUnits",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCUgUnits_UgUnitId",
                table: "FormCUgUnits",
                column: "UgUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_FormGuestUnits_FormCId",
                table: "FormGuestUnits",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormGuestUnits_GuestUnitId",
                table: "FormGuestUnits",
                column: "GuestUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_CruiseDaysDetails_FormsC_FormCId",
                table: "CruiseDaysDetails",
                column: "FormCId",
                principalTable: "FormsC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormsB_ResearchAreas_ResearchAreaId",
                table: "FormsB",
                column: "ResearchAreaId",
                principalTable: "ResearchAreas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormsC_ResearchAreas_ResearchAreaId",
                table: "FormsC",
                column: "ResearchAreaId",
                principalTable: "ResearchAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_FormsC_FormCId",
                table: "Permissions",
                column: "FormCId",
                principalTable: "FormsC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipEquipments_FormsC_FormCId",
                table: "ShipEquipments",
                column: "FormCId",
                principalTable: "FormsC",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CruiseDaysDetails_FormsC_FormCId",
                table: "CruiseDaysDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FormsB_ResearchAreas_ResearchAreaId",
                table: "FormsB");

            migrationBuilder.DropForeignKey(
                name: "FK_FormsC_ResearchAreas_ResearchAreaId",
                table: "FormsC");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_FormsC_FormCId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipEquipments_FormsC_FormCId",
                table: "ShipEquipments");

            migrationBuilder.DropTable(
                name: "CollectedSamples");

            migrationBuilder.DropTable(
                name: "CruiseApplicationEffects");

            migrationBuilder.DropTable(
                name: "FormCLongResearchEquipments");

            migrationBuilder.DropTable(
                name: "FormCPorts");

            migrationBuilder.DropTable(
                name: "FormCResearchEquipments");

            migrationBuilder.DropTable(
                name: "FormCShortResearchEquipments");

            migrationBuilder.DropTable(
                name: "FormCSpubTasks");

            migrationBuilder.DropTable(
                name: "FormCUgUnits");

            migrationBuilder.DropTable(
                name: "FormGuestUnits");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "FormCResearchTasks");

            migrationBuilder.DropIndex(
                name: "IX_ShipEquipments_FormCId",
                table: "ShipEquipments");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_FormCId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_FormsC_ResearchAreaId",
                table: "FormsC");

            migrationBuilder.DropIndex(
                name: "IX_FormsB_ResearchAreaId",
                table: "FormsB");

            migrationBuilder.DropIndex(
                name: "IX_CruiseDaysDetails_FormCId",
                table: "CruiseDaysDetails");

            migrationBuilder.DropColumn(
                name: "FormCId",
                table: "ShipEquipments");

            migrationBuilder.DropColumn(
                name: "FormCId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "AdditionalDescription",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "AdditionalSpubData",
                table: "FormsC");

            migrationBuilder.DropColumn(
                name: "ResearchAreaId",
                table: "FormsB");

            migrationBuilder.DropColumn(
                name: "FormCId",
                table: "CruiseDaysDetails");

            migrationBuilder.RenameColumn(
                name: "ResearchAreaId",
                table: "FormsC",
                newName: "DeputyManagerId");

            migrationBuilder.AddColumn<Guid>(
                name: "FormCId",
                table: "SpubTasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormCId",
                table: "ResearchTasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormCId",
                table: "Publications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShipUsage",
                table: "FormsC",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddColumn<int>(
                name: "AcceptablePeriodBeg",
                table: "FormsC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcceptablePeriodEnd",
                table: "FormsC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CruiseGoal",
                table: "FormsC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CruiseGoalDescription",
                table: "FormsC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CruiseHours",
                table: "FormsC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CruiseManagerId",
                table: "FormsC",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "OptimalPeriodBeg",
                table: "FormsC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OptimalPeriodEnd",
                table: "FormsC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PeriodNotes",
                table: "FormsC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Permissions",
                table: "FormsC",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PermissionsRequired",
                table: "FormsC",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ResearchArea",
                table: "FormsC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "FormsC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "FormBShortResearchEquipments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "FormBShortResearchEquipments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Permission",
                table: "FormBResearchEquipments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "Insurance",
                table: "FormBResearchEquipments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddColumn<Guid>(
                name: "FormCId",
                table: "FormAUgUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormCId",
                table: "FormAGuestUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpubTasks_FormCId",
                table: "SpubTasks",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchTasks_FormCId",
                table: "ResearchTasks",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_FormCId",
                table: "Publications",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAUgUnits_FormCId",
                table: "FormAUgUnits",
                column: "FormCId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAGuestUnits_FormCId",
                table: "FormAGuestUnits",
                column: "FormCId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormAGuestUnits_FormsC_FormCId",
                table: "FormAGuestUnits",
                column: "FormCId",
                principalTable: "FormsC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormAUgUnits_FormsC_FormCId",
                table: "FormAUgUnits",
                column: "FormCId",
                principalTable: "FormsC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_FormsC_FormCId",
                table: "Publications",
                column: "FormCId",
                principalTable: "FormsC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchTasks_FormsC_FormCId",
                table: "ResearchTasks",
                column: "FormCId",
                principalTable: "FormsC",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpubTasks_FormsC_FormCId",
                table: "SpubTasks",
                column: "FormCId",
                principalTable: "FormsC",
                principalColumn: "Id");
        }
    }
}
