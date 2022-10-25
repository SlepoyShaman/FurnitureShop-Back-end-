using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureShop.Migrations
{
    public partial class ChangeHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Img", "Name", "Price" },
                values: new object[] { 4, 2, "img/bg-img/4.jpg", "Night Stand", 100m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
