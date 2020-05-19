using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup.Api.Migrations
{
    public partial class fixedemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_Employees_EmployeeId",
                table: "Specialty");

            migrationBuilder.DropIndex(
                name: "IX_Specialty_EmployeeId",
                table: "Specialty");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Specialty");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyID",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SpecialtyID",
                table: "Employees",
                column: "SpecialtyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Specialty_SpecialtyID",
                table: "Employees",
                column: "SpecialtyID",
                principalTable: "Specialty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Specialty_SpecialtyID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SpecialtyID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SpecialtyID",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Specialty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Specialty_EmployeeId",
                table: "Specialty",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_Employees_EmployeeId",
                table: "Specialty",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
