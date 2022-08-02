using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redestro.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcheId",
                table: "Tache",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Stagiaire",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Stagiaire",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Instructeur",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateEmbauche = table.Column<DateTime>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    telephone = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructeur", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InstructeurTache",
                columns: table => new
                {
                    InstructeursID = table.Column<int>(type: "INTEGER", nullable: false),
                    TachesTacheID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructeurTache", x => new { x.InstructeursID, x.TachesTacheID });
                    table.ForeignKey(
                        name: "FK_InstructeurTache_Instructeur_InstructeursID",
                        column: x => x.InstructeursID,
                        principalTable: "Instructeur",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructeurTache_Tache_TachesTacheID",
                        column: x => x.TachesTacheID,
                        principalTable: "Tache",
                        principalColumn: "TacheID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marches",
                columns: table => new
                {
                    MarcheId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Budget = table.Column<decimal>(type: "Budget", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InstructeurID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marches", x => x.MarcheId);
                    table.ForeignKey(
                        name: "FK_Marches_Instructeur_InstructeurID",
                        column: x => x.InstructeurID,
                        principalTable: "Instructeur",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tache_MarcheId",
                table: "Tache",
                column: "MarcheId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructeurTache_TachesTacheID",
                table: "InstructeurTache",
                column: "TachesTacheID");

            migrationBuilder.CreateIndex(
                name: "IX_Marches_InstructeurID",
                table: "Marches",
                column: "InstructeurID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tache_Marches_MarcheId",
                table: "Tache",
                column: "MarcheId",
                principalTable: "Marches",
                principalColumn: "MarcheId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tache_Marches_MarcheId",
                table: "Tache");

            migrationBuilder.DropTable(
                name: "InstructeurTache");

            migrationBuilder.DropTable(
                name: "Marches");

            migrationBuilder.DropTable(
                name: "Instructeur");

            migrationBuilder.DropIndex(
                name: "IX_Tache_MarcheId",
                table: "Tache");

            migrationBuilder.DropColumn(
                name: "MarcheId",
                table: "Tache");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Stagiaire",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Stagiaire",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);
        }
    }
}
