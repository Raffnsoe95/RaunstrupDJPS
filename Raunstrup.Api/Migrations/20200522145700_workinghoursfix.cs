using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup.Api.Migrations
{
    public partial class workinghoursfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployees_Employees_EmployeeID",
                table: "ProjectEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Employees_EmployeeID",
                table: "WorkingHours");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "WorkingHours",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "ProjectEmployees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployees_Employees_EmployeeID",
                table: "ProjectEmployees",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Employees_EmployeeID",
                table: "WorkingHours",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployees_Employees_EmployeeID",
                table: "ProjectEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Employees_EmployeeID",
                table: "WorkingHours");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "WorkingHours",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "ProjectEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployees_Employees_EmployeeID",
                table: "ProjectEmployees",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Employees_EmployeeID",
                table: "WorkingHours",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
