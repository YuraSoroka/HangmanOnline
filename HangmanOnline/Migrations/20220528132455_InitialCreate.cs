using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangmanOnline.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Health = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerOneId = table.Column<int>(type: "int", nullable: true),
                    PlayerTwoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Player_PlayerOneId",
                        column: x => x.PlayerOneId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_Player_PlayerTwoId",
                        column: x => x.PlayerTwoId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PlayerOneId",
                table: "Rooms",
                column: "PlayerOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PlayerTwoId",
                table: "Rooms",
                column: "PlayerTwoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
