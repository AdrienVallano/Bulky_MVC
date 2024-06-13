using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EnteteEtDetailCommande : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntetesCommandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Datecommande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLivraison = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCommande = table.Column<double>(type: "float", nullable: false),
                    StatutCommande = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatutPayement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDeSuivi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transporteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePayement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EcheancePayement = table.Column<DateOnly>(type: "date", nullable: false),
                    IdentifiantPayement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntetesCommandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntetesCommandes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailCommandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnteteCommandeId = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailCommandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailCommandes_EntetesCommandes_EnteteCommandeId",
                        column: x => x.EnteteCommandeId,
                        principalTable: "EntetesCommandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailCommandes_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailCommandes_EnteteCommandeId",
                table: "DetailCommandes",
                column: "EnteteCommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCommandes_ProduitId",
                table: "DetailCommandes",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_EntetesCommandes_ApplicationUserId",
                table: "EntetesCommandes",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailCommandes");

            migrationBuilder.DropTable(
                name: "EntetesCommandes");
        }
    }
}
