using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PillsReminder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DozaMedicament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantitate_pastila = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Luata = table.Column<bool>(type: "bit", nullable: false),
                    MedicamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DozaMedicament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DozaMedicament_Medicament_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListaMedicament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaMedicament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaMedicament_Medicament_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListaMedicamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_ListaMedicament_ListaMedicamentId",
                        column: x => x.ListaMedicamentId,
                        principalTable: "ListaMedicament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUtilizator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresa_Users_IdUtilizator",
                        column: x => x.IdUtilizator,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DozaMedicamentUser",
                columns: table => new
                {
                    DozaMedicamentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DozaMedicamentUser", x => new { x.DozaMedicamentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_DozaMedicamentUser_DozaMedicament_DozaMedicamentId",
                        column: x => x.DozaMedicamentId,
                        principalTable: "DozaMedicament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DozaMedicamentUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresa_IdUtilizator",
                table: "Adresa",
                column: "IdUtilizator",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DozaMedicament_MedicamentId",
                table: "DozaMedicament",
                column: "MedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_DozaMedicamentUser_UserId",
                table: "DozaMedicamentUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaMedicament_MedicamentId",
                table: "ListaMedicament",
                column: "MedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ListaMedicamentId",
                table: "Users",
                column: "ListaMedicamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresa");

            migrationBuilder.DropTable(
                name: "DozaMedicamentUser");

            migrationBuilder.DropTable(
                name: "DozaMedicament");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ListaMedicament");

            migrationBuilder.DropTable(
                name: "Medicament");
        }
    }
}
