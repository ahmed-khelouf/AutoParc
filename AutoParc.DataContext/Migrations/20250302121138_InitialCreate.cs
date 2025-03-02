using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoParc.DataContext.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entreprise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContratActif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntrepriseId = table.Column<int>(type: "int", nullable: false),
                    VehiculeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employe_Entreprise_EntrepriseId",
                        column: x => x.EntrepriseId,
                        principalTable: "Entreprise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponibilite = table.Column<bool>(type: "bit", nullable: false),
                    RaisonIndisponibilite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntrepriseId = table.Column<int>(type: "int", nullable: false),
                    EmployeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicule_Employe_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicule_Entreprise_EntrepriseId",
                        column: x => x.EntrepriseId,
                        principalTable: "Entreprise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Entreprise",
                columns: new[] { "Id", "ContratActif", "Nom" },
                values: new object[] { 1, true, "Test 1" });

            migrationBuilder.InsertData(
                table: "Entreprise",
                columns: new[] { "Id", "ContratActif", "Nom" },
                values: new object[] { 2, false, "Test 2" });

            migrationBuilder.InsertData(
                table: "Entreprise",
                columns: new[] { "Id", "ContratActif", "Nom" },
                values: new object[] { 3, true, "Test 3" });

            migrationBuilder.InsertData(
                table: "Vehicule",
                columns: new[] { "Id", "Disponibilite", "EmployeId", "EntrepriseId", "Marque", "Modele", "RaisonIndisponibilite" },
                values: new object[] { 1, true, null, 1, "Test 1", "Test 1", null });

            migrationBuilder.InsertData(
                table: "Vehicule",
                columns: new[] { "Id", "Disponibilite", "EmployeId", "EntrepriseId", "Marque", "Modele", "RaisonIndisponibilite" },
                values: new object[] { 2, false, null, 2, "Test 2", "Test 2", "Test 2" });

            migrationBuilder.InsertData(
                table: "Vehicule",
                columns: new[] { "Id", "Disponibilite", "EmployeId", "EntrepriseId", "Marque", "Modele", "RaisonIndisponibilite" },
                values: new object[] { 3, true, null, 3, "Test 3", "Test 3", null });

            migrationBuilder.InsertData(
                table: "Employe",
                columns: new[] { "Id", "EntrepriseId", "Nom", "Prenom", "VehiculeId" },
                values: new object[] { 1, 1, "Test 1", "Test 1", 1 });

            migrationBuilder.InsertData(
                table: "Employe",
                columns: new[] { "Id", "EntrepriseId", "Nom", "Prenom", "VehiculeId" },
                values: new object[] { 2, 2, "Test 2", "Test 2", 2 });

            migrationBuilder.InsertData(
                table: "Employe",
                columns: new[] { "Id", "EntrepriseId", "Nom", "Prenom", "VehiculeId" },
                values: new object[] { 3, 3, "Test 3", "Test 3", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Employe_EntrepriseId",
                table: "Employe",
                column: "EntrepriseId");

            migrationBuilder.CreateIndex(
                name: "IX_Employe_VehiculeId",
                table: "Employe",
                column: "VehiculeId",
                unique: true,
                filter: "[VehiculeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_EmployeId",
                table: "Vehicule",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_EntrepriseId",
                table: "Vehicule",
                column: "EntrepriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employe_Vehicule_VehiculeId",
                table: "Employe",
                column: "VehiculeId",
                principalTable: "Vehicule",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employe_Entreprise_EntrepriseId",
                table: "Employe");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_Entreprise_EntrepriseId",
                table: "Vehicule");

            migrationBuilder.DropForeignKey(
                name: "FK_Employe_Vehicule_VehiculeId",
                table: "Employe");

            migrationBuilder.DropTable(
                name: "Entreprise");

            migrationBuilder.DropTable(
                name: "Vehicule");

            migrationBuilder.DropTable(
                name: "Employe");
        }
    }
}
