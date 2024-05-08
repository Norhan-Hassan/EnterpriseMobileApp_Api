using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMobileApp_ASS1.Migrations
{
    /// <inheritdoc />
    public partial class fav2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Store_StoreId",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Store_StoreId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Store");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Store",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_StoreId",
                table: "Store",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Store_StoreId",
                table: "Store",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id");
        }
    }
}
