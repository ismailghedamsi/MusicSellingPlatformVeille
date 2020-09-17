using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicSellingApp.Server.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Artists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_AccountId",
                table: "Artists",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Accounts_AccountId",
                table: "Artists",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Accounts_AccountId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_AccountId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Artists");
        }
    }
}
