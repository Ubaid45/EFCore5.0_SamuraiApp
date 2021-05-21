using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class m2mpayload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Battle_BattlesBattleId",
                table: "BattleSamurai");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Samurais_SamuraisId",
                table: "BattleSamurai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battle",
                table: "Battle");

            migrationBuilder.RenameTable(
                name: "Battle",
                newName: "Battles");

            migrationBuilder.RenameColumn(
                name: "SamuraisId",
                table: "BattleSamurai",
                newName: "SamuraiId");

            migrationBuilder.RenameColumn(
                name: "BattlesBattleId",
                table: "BattleSamurai",
                newName: "BattleId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleSamurai_SamuraisId",
                table: "BattleSamurai",
                newName: "IX_BattleSamurai_SamuraiId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                table: "BattleSamurai",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                column: "BattleId");

            migrationBuilder.CreateTable(
                name: "Horse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamuraiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horse_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horse_SamuraiId",
                table: "Horse",
                column: "SamuraiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Battles_BattleId",
                table: "BattleSamurai",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "BattleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Samurais_SamuraiId",
                table: "BattleSamurai",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Battles_BattleId",
                table: "BattleSamurai");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Samurais_SamuraiId",
                table: "BattleSamurai");

            migrationBuilder.DropTable(
                name: "Horse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "BattleSamurai");

            migrationBuilder.RenameTable(
                name: "Battles",
                newName: "Battle");

            migrationBuilder.RenameColumn(
                name: "SamuraiId",
                table: "BattleSamurai",
                newName: "SamuraisId");

            migrationBuilder.RenameColumn(
                name: "BattleId",
                table: "BattleSamurai",
                newName: "BattlesBattleId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleSamurai_SamuraiId",
                table: "BattleSamurai",
                newName: "IX_BattleSamurai_SamuraisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battle",
                table: "Battle",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Battle_BattlesBattleId",
                table: "BattleSamurai",
                column: "BattlesBattleId",
                principalTable: "Battle",
                principalColumn: "BattleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Samurais_SamuraisId",
                table: "BattleSamurai",
                column: "SamuraisId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
