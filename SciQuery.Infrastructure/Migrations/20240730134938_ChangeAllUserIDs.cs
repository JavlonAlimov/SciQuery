using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SciQuery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAllUserIDs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReputationChange_AspNetUsers_UserId1",
                table: "ReputationChange");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_AspNetUsers_UserId1",
                table: "Vote");

            migrationBuilder.DropIndex(
                name: "IX_Vote_UserId1",
                table: "Vote");

            migrationBuilder.DropIndex(
                name: "IX_ReputationChange_UserId1",
                table: "ReputationChange");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Vote");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ReputationChange");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Vote",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ReputationChange",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_UserId",
                table: "Vote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReputationChange_UserId",
                table: "ReputationChange",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReputationChange_AspNetUsers_UserId",
                table: "ReputationChange",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_AspNetUsers_UserId",
                table: "Vote",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReputationChange_AspNetUsers_UserId",
                table: "ReputationChange");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_AspNetUsers_UserId",
                table: "Vote");

            migrationBuilder.DropIndex(
                name: "IX_Vote_UserId",
                table: "Vote");

            migrationBuilder.DropIndex(
                name: "IX_ReputationChange_UserId",
                table: "ReputationChange");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Vote",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Vote",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ReputationChange",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ReputationChange",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vote_UserId1",
                table: "Vote",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReputationChange_UserId1",
                table: "ReputationChange",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ReputationChange_AspNetUsers_UserId1",
                table: "ReputationChange",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_AspNetUsers_UserId1",
                table: "Vote",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
