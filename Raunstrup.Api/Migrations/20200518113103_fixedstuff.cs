using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup.Api.Migrations
{
    public partial class fixedstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemDiscountTypes");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "CustomerDiscountTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemDiscountTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "CustomerDiscountTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
