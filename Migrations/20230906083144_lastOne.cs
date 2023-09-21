using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoreApp.Migrations
{
    /// <inheritdoc />
    public partial class lastOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Owners",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_CarId",
                table: "Owners",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Car_CarId",
                table: "Owners",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Car_CarId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_CarId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Owners");
        }
    }
}
