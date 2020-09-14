using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicSellingApp.Server.Migrations
{
    public partial class UsersTableUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_accountId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "accountId",
                table: "Users",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_accountId",
                table: "Users",
                newName: "IX_Users_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_AccountId",
                table: "Users",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_AccountId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Users",
                newName: "accountId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                newName: "IX_Users_accountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_accountId",
                table: "Users",
                column: "accountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
