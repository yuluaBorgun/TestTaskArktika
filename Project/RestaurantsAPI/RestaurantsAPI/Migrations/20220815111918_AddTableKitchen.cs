using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantsAPI.Migrations
{
    public partial class AddTableKitchen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kitchen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NameKitchen = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitchen", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_KitchenID",
                table: "Restaurant",
                column: "KitchenID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Kitchen_KitchenID",
                table: "Restaurant",
                column: "KitchenID",
                principalTable: "Kitchen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Kitchen_KitchenID",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "Kitchen");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_KitchenID",
                table: "Restaurant");
        }
    }
}
