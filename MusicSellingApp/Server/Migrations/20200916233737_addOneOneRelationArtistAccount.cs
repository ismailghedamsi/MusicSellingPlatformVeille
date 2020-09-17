using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicSellingApp.Server.Migrations
{
    public partial class addOneOneRelationArtistAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Artists",
                type: "bigint",
                nullable: true);

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
    }
}
