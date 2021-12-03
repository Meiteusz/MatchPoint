using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchPoint.BackEnd.GameAPI.Migrations
{
    public partial class DeletingTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerOneId1 = table.Column<int>(type: "int", nullable: true),
                    PlayerOneIdId = table.Column<int>(type: "int", nullable: true),
                    PlayerTwoId1 = table.Column<int>(type: "int", nullable: true),
                    PlayerTwoIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Player_PlayerOneId1",
                        column: x => x.PlayerOneId1,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Game_Player_PlayerOneIdId",
                        column: x => x.PlayerOneIdId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Game_Player_PlayerTwoId1",
                        column: x => x.PlayerTwoId1,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Game_Player_PlayerTwoIdId",
                        column: x => x.PlayerTwoIdId,
                        principalTable: "Player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointsOne = table.Column<int>(type: "int", nullable: false),
                    PointsTwo = table.Column<int>(type: "int", nullable: false),
                    MaxPoints = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Score_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerOneId1",
                table: "Game",
                column: "PlayerOneId1");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerOneIdId",
                table: "Game",
                column: "PlayerOneIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerTwoId1",
                table: "Game",
                column: "PlayerTwoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerTwoIdId",
                table: "Game",
                column: "PlayerTwoIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_GameId",
                table: "Score",
                column: "GameId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
