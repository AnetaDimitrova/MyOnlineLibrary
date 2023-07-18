using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyOnlineLibrary.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryUserBook_AspNetUsers_ApplicationUserId",
                table: "LibraryUserBook");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "LibraryUserBook",
                newName: "LibraryUserId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryUserBook_ApplicationUserId",
                table: "LibraryUserBook",
                newName: "IX_LibraryUserBook_LibraryUserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryUserBook_AspNetUsers_LibraryUserId",
                table: "LibraryUserBook",
                column: "LibraryUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryUserBook_AspNetUsers_LibraryUserId",
                table: "LibraryUserBook");

            migrationBuilder.RenameColumn(
                name: "LibraryUserId",
                table: "LibraryUserBook",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryUserBook_LibraryUserId",
                table: "LibraryUserBook",
                newName: "IX_LibraryUserBook_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryUserBook_AspNetUsers_ApplicationUserId",
                table: "LibraryUserBook",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
