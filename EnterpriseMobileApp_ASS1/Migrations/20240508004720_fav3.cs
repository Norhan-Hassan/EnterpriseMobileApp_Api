using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMobileApp_ASS1.Migrations
{
    /// <inheritdoc />
    public partial class fav3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Student_StudentId",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Store_StudentId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Store");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Store",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_StudentId",
                table: "Store",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Student_StudentId",
                table: "Store",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");
        }
    }
}
