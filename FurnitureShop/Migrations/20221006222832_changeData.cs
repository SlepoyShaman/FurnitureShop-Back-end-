using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureShop.Migrations
{
    public partial class changeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Img", "Name", "Price" },
                values: new object[,]
                {
                    { 5, 1, "img/bg-img/5.jpg", "Plant Po", 18m },
                    { 6, 2, "img/bg-img/6.jpg", "Small Table", 320m },
                    { 7, 1, "img/bg-img/7.jpg", "Metallic Chair", 318m },
                    { 8, 2, "img/bg-img/8.jpg", "Modern Rocking Chair", 318m },
                    { 9, 1, "img/bg-img/9.jpg", "Home Deco", 318m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
