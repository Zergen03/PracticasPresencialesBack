using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UserCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIES_UserId",
                table: "CATEGORIES",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CATEGORIES_USERS_UserId",
                table: "CATEGORIES",
                column: "UserId",
                principalTable: "USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CATEGORIES_USERS_UserId",
                table: "CATEGORIES");

            migrationBuilder.DropIndex(
                name: "IX_CATEGORIES_UserId",
                table: "CATEGORIES");
        }
    }
}
