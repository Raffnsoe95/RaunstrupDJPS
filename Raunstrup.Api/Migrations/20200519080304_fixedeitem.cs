using Microsoft.EntityFrameworkCore.Migrations;

namespace Raunstrup.Api.Migrations
{
    public partial class fixedeitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemDiscountTypes_DiscountID",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountID",
                table: "Items",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemDiscountTypes_DiscountID",
                table: "Items",
                column: "DiscountID",
                principalTable: "ItemDiscountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemDiscountTypes_DiscountID",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountID",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemDiscountTypes_DiscountID",
                table: "Items",
                column: "DiscountID",
                principalTable: "ItemDiscountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
