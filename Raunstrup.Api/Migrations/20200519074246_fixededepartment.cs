using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup.Api.Migrations
{
    public partial class fixededepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Department");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
