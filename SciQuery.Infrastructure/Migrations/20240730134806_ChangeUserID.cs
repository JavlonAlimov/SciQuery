using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SciQuery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_UserId1",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserId1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Questions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AspNetUsers_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_UserId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Questions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId1",
                table: "Questions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AspNetUsers_UserId1",
                table: "Questions",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
