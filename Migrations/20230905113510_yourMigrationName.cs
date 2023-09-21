using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoreApp.Migrations
{
    /// <inheritdoc />
    public partial class yourMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopReg_Car_CarsCarId",
                table: "ShopReg");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopReg_Shops_ShopsShopId",
                table: "ShopReg");

            migrationBuilder.DropIndex(
                name: "IX_ShopReg_CarsCarId",
                table: "ShopReg");

            migrationBuilder.DropIndex(
                name: "IX_ShopReg_ShopsShopId",
                table: "ShopReg");

            migrationBuilder.DropColumn(
                name: "CarsCarId",
                table: "ShopReg");

            migrationBuilder.DropColumn(
                name: "ShopsShopId",
                table: "ShopReg");

            migrationBuilder.CreateIndex(
                name: "IX_ShopReg_CarId",
                table: "ShopReg",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopReg_ShopId",
                table: "ShopReg",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopReg_Car_CarId",
                table: "ShopReg",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopReg_Shops_ShopId",
                table: "ShopReg",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "ShopId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopReg_Car_CarId",
                table: "ShopReg");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopReg_Shops_ShopId",
                table: "ShopReg");

            migrationBuilder.DropIndex(
                name: "IX_ShopReg_CarId",
                table: "ShopReg");

            migrationBuilder.DropIndex(
                name: "IX_ShopReg_ShopId",
                table: "ShopReg");

            migrationBuilder.AddColumn<int>(
                name: "CarsCarId",
                table: "ShopReg",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopsShopId",
                table: "ShopReg",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopReg_CarsCarId",
                table: "ShopReg",
                column: "CarsCarId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopReg_ShopsShopId",
                table: "ShopReg",
                column: "ShopsShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopReg_Car_CarsCarId",
                table: "ShopReg",
                column: "CarsCarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopReg_Shops_ShopsShopId",
                table: "ShopReg",
                column: "ShopsShopId",
                principalTable: "Shops",
                principalColumn: "ShopId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
