using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Port_web.Migrations
{
    public partial class ProductKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromPurchase",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "FromPurchase",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
