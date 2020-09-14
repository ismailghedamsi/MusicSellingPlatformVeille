using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicSellingApp.Server.Migrations
{
    public partial class completeContextConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_TrackList_TrackListId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_TrackList_TrackListId",
                table: "Song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackList",
                table: "TrackList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Song",
                table: "Song");

            migrationBuilder.RenameTable(
                name: "TrackList",
                newName: "TrackLists");

            migrationBuilder.RenameTable(
                name: "Song",
                newName: "Songs");

            migrationBuilder.RenameIndex(
                name: "IX_Song_TrackListId",
                table: "Songs",
                newName: "IX_Songs_TrackListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackLists",
                table: "TrackLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fanId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_fanId",
                        column: x => x.fanId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_fanId",
                table: "Carts",
                column: "fanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_TrackLists_TrackListId",
                table: "Albums",
                column: "TrackListId",
                principalTable: "TrackLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_TrackLists_TrackListId",
                table: "Songs",
                column: "TrackListId",
                principalTable: "TrackLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_TrackLists_TrackListId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_TrackLists_TrackListId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackLists",
                table: "TrackLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.RenameTable(
                name: "TrackLists",
                newName: "TrackList");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "Song");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_TrackListId",
                table: "Song",
                newName: "IX_Song_TrackListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackList",
                table: "TrackList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Song",
                table: "Song",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_TrackList_TrackListId",
                table: "Albums",
                column: "TrackListId",
                principalTable: "TrackList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_TrackList_TrackListId",
                table: "Song",
                column: "TrackListId",
                principalTable: "TrackList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
