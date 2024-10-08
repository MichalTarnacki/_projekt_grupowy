using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchCruiseApp_API.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInsuranceDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Insurance",
                table: "FormBResearchEquipments");

            migrationBuilder.AddColumn<string>(
                name: "InsuranceEndDate",
                table: "FormBResearchEquipments",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceStartDate",
                table: "FormBResearchEquipments",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceEndDate",
                table: "FormBResearchEquipments");

            migrationBuilder.DropColumn(
                name: "InsuranceStartDate",
                table: "FormBResearchEquipments");

            migrationBuilder.AddColumn<string>(
                name: "Insurance",
                table: "FormBResearchEquipments",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");
        }
    }
}
