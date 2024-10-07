using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFormsListsToShipEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipEquipments_FormsB_FormBId",
                table: "ShipEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipEquipments_FormsC_FormCId",
                table: "ShipEquipments");

            migrationBuilder.DropIndex(
                name: "IX_ShipEquipments_FormBId",
                table: "ShipEquipments");

            migrationBuilder.DropIndex(
                name: "IX_ShipEquipments_FormCId",
                table: "ShipEquipments");

            migrationBuilder.DropColumn(
                name: "FormBId",
                table: "ShipEquipments");

            migrationBuilder.DropColumn(
                name: "FormCId",
                table: "ShipEquipments");

            migrationBuilder.CreateTable(
                name: "FormBShipEquipment",
                columns: table => new
                {
                    FormsBId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipEquipmentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBShipEquipment", x => new { x.FormsBId, x.ShipEquipmentsId });
                    table.ForeignKey(
                        name: "FK_FormBShipEquipment_FormsB_FormsBId",
                        column: x => x.FormsBId,
                        principalTable: "FormsB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormBShipEquipment_ShipEquipments_ShipEquipmentsId",
                        column: x => x.ShipEquipmentsId,
                        principalTable: "ShipEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormCShipEquipment",
                columns: table => new
                {
                    FormsCId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipEquipmentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCShipEquipment", x => new { x.FormsCId, x.ShipEquipmentsId });
                    table.ForeignKey(
                        name: "FK_FormCShipEquipment_FormsC_FormsCId",
                        column: x => x.FormsCId,
                        principalTable: "FormsC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormCShipEquipment_ShipEquipments_ShipEquipmentsId",
                        column: x => x.ShipEquipmentsId,
                        principalTable: "ShipEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormBShipEquipment_ShipEquipmentsId",
                table: "FormBShipEquipment",
                column: "ShipEquipmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_FormCShipEquipment_ShipEquipmentsId",
                table: "FormCShipEquipment",
                column: "ShipEquipmentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormBShipEquipment");

            migrationBuilder.DropTable(
                name: "FormCShipEquipment");

            migrationBuilder.AddColumn<Guid>(
                name: "FormBId",
                table: "ShipEquipments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormCId",
                table: "ShipEquipments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShipEquipments_FormBId",
                table: "ShipEquipments",
                column: "FormBId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipEquipments_FormCId",
                table: "ShipEquipments",
                column: "FormCId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipEquipments_FormsB_FormBId",
                table: "ShipEquipments",
                column: "FormBId",
                principalTable: "FormsB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipEquipments_FormsC_FormCId",
                table: "ShipEquipments",
                column: "FormCId",
                principalTable: "FormsC",
                principalColumn: "Id");
        }
    }
}
