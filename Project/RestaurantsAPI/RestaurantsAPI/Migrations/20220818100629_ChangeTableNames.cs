using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantsAPI.Migrations
{
    public partial class ChangeTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Kitchen_KitchenID",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kitchen",
                table: "Kitchen");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                newName: "Restaurants");

            migrationBuilder.RenameTable(
                name: "Kitchen",
                newName: "Kitchens");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_KitchenID",
                table: "Restaurants",
                newName: "IX_Restaurants_KitchenID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kitchens",
                table: "Kitchens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Kitchens_KitchenID",
                table: "Restaurants",
                column: "KitchenID",
                principalTable: "Kitchens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Kitchens_KitchenID",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kitchens",
                table: "Kitchens");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Restaurant");

            migrationBuilder.RenameTable(
                name: "Kitchens",
                newName: "Kitchen");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_KitchenID",
                table: "Restaurant",
                newName: "IX_Restaurant_KitchenID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kitchen",
                table: "Kitchen",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Kitchen_KitchenID",
                table: "Restaurant",
                column: "KitchenID",
                principalTable: "Kitchen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
