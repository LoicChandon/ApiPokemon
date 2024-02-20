using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiPokemon.Migrations
{
    public partial class PokemonDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dresseur",
                columns: table => new
                {
                    iddresseur = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pseudodresseur = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    genredresseur = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    heuredejeudresseur = table.Column<double>(type: "double precision", nullable: false),
                    datecreationdresseur = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dresseur", x => x.iddresseur);
                    table.CheckConstraint("ck_dresseur_heuresdejeu", "heuredejeudresseur >= 0");
                });

            migrationBuilder.CreateTable(
                name: "pokemon",
                columns: table => new
                {
                    idpokemon = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nompokemon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    type1pokemon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    type2pokemon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    basepvpokemon = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemon", x => x.idpokemon);
                });

            migrationBuilder.CreateTable(
                name: "capture",
                columns: table => new
                {
                    idpokemon = table.Column<int>(type: "integer", nullable: false),
                    iddresseur = table.Column<int>(type: "integer", nullable: false),
                    datecapture = table.Column<DateTime>(type: "date", nullable: false),
                    surnompokemon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_capture", x => new { x.iddresseur, x.idpokemon });
                    table.ForeignKey(
                        name: "fk_capture_id_dresseur",
                        column: x => x.iddresseur,
                        principalTable: "dresseur",
                        principalColumn: "iddresseur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_capture_id_pokemon",
                        column: x => x.idpokemon,
                        principalTable: "pokemon",
                        principalColumn: "idpokemon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_capture_idpokemon",
                table: "capture",
                column: "idpokemon");

            migrationBuilder.CreateIndex(
                name: "IX_dresseur_pseudodresseur",
                table: "dresseur",
                column: "pseudodresseur",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pokemon_nompokemon",
                table: "pokemon",
                column: "nompokemon",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "capture");

            migrationBuilder.DropTable(
                name: "dresseur");

            migrationBuilder.DropTable(
                name: "pokemon");
        }
    }
}
