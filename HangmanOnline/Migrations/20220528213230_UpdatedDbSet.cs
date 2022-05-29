using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangmanOnline.Migrations
{
    public partial class UpdatedDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Player_PlayerOneId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Player_PlayerTwoId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Players_PlayerOneId",
                table: "Rooms",
                column: "PlayerOneId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Players_PlayerTwoId",
                table: "Rooms",
                column: "PlayerTwoId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Players_PlayerOneId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Players_PlayerTwoId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Player_PlayerOneId",
                table: "Rooms",
                column: "PlayerOneId",
                principalTable: "Player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Player_PlayerTwoId",
                table: "Rooms",
                column: "PlayerTwoId",
                principalTable: "Player",
                principalColumn: "Id");
        }
    }
}
