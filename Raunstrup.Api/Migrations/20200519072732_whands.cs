using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup.Api.Migrations
{
    public partial class whands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Specialty_EmployeeId",
                table: "Specialty");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeType");

            migrationBuilder.CreateIndex(
                name: "IX_Specialty_EmployeeId",
                table: "Specialty",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Specialty_EmployeeId",
                table: "Specialty");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "EmployeeType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Specialty_EmployeeId",
                table: "Specialty",
                column: "EmployeeId");
        }
    }
}
