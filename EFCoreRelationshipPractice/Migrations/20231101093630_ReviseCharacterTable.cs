using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreRelationshipPractice.Migrations
{
    /// <inheritdoc />
    public partial class ReviseCharacterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Backpacks_BackpackId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_BackpackId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "BackpackId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Backpacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Backpacks_CharacterId",
                table: "Backpacks",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Backpacks_Characters_CharacterId",
                table: "Backpacks",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Backpacks_Characters_CharacterId",
                table: "Backpacks");

            migrationBuilder.DropIndex(
                name: "IX_Backpacks_CharacterId",
                table: "Backpacks");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Backpacks");

            migrationBuilder.AddColumn<int>(
                name: "BackpackId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BackpackId",
                table: "Characters",
                column: "BackpackId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Backpacks_BackpackId",
                table: "Characters",
                column: "BackpackId",
                principalTable: "Backpacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
