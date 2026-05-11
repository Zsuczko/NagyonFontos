using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemApi.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_705 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rendezos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    Nemzetiseg = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rendezos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cim = table.Column<string>(type: "TEXT", nullable: false),
                    Mufaj = table.Column<string>(type: "TEXT", nullable: false),
                    Ev = table.Column<int>(type: "INTEGER", nullable: false),
                    RendezoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Rendezos_RendezoId",
                        column: x => x.RendezoId,
                        principalTable: "Rendezos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vetitesek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Terem = table.Column<int>(type: "INTEGER", nullable: false),
                    JegyAr = table.Column<int>(type: "INTEGER", nullable: false),
                    Idopont = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vetitesek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vetitesek_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_RendezoId",
                table: "Films",
                column: "RendezoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vetitesek_FilmId",
                table: "Vetitesek",
                column: "FilmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vetitesek");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Rendezos");
        }
    }
}
