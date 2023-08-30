using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitMediaContentService.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Track_Id",
                table: "Track",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Release_Id",
                table: "Release",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Id",
                table: "Artist",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Track_Id",
                table: "Track");

            migrationBuilder.DropIndex(
                name: "IX_Release_Id",
                table: "Release");

            migrationBuilder.DropIndex(
                name: "IX_Artist_Id",
                table: "Artist");
        }
    }
}
