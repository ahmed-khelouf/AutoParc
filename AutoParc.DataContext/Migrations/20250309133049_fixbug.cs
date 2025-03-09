using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoParc.DataContext.Migrations
{
    public partial class fixbug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_Employe_EmployeId",
                table: "Vehicule");

            migrationBuilder.DropIndex(
                name: "IX_Vehicule_EmployeId",
                table: "Vehicule");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role-admin",
                column: "ConcurrencyStamp",
                value: "c7d8673a-1824-4637-af26-76ec15a596bc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ede39afd-78b8-484c-8002-20971b69ca36", "AQAAAAEAACcQAAAAEKsAbsa4WBkvrPuowyFFzBtqg0vJwgz/I0bzEVgTxvmH4IVRffZJlo7yUa9AoPp9Uw==", "b0405f1d-8273-4f5d-bbb1-9d175d7ab894" });

            migrationBuilder.InsertData(
                table: "Vehicule",
                columns: new[] { "Id", "Disponibilite", "EmployeId", "EntrepriseId", "Marque", "Modele", "RaisonIndisponibilite" },
                values: new object[,]
                {
                    { 4, true, 4, 3, "Test 4", "Test 4", null },
                    { 5, true, 5, 3, "Test 5", "Test 5", null }
                });

            migrationBuilder.InsertData(
                table: "Employe",
                columns: new[] { "Id", "EntrepriseId", "Nom", "Prenom", "VehiculeId" },
                values: new object[] { 4, 3, "Test 4", "Test 4", 4 });

            migrationBuilder.InsertData(
                table: "Employe",
                columns: new[] { "Id", "EntrepriseId", "Nom", "Prenom", "VehiculeId" },
                values: new object[] { 5, 3, "Test 5", "Test 5", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employe",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employe",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicule",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicule",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role-admin",
                column: "ConcurrencyStamp",
                value: "581602e6-659b-465d-ac32-39f870ae2872");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9d26257-8bf6-450f-aa7b-4ff27538c0b7", "AQAAAAEAACcQAAAAEK0L0gBsi5cX7er9dndclNJV7F0xhAuTG08ZjaXW0O1EMcxNLgvpWRah6xpNfygOzA==", "db759dce-12c4-47ce-9ee9-1e03638f388f" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicule_EmployeId",
                table: "Vehicule",
                column: "EmployeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicule_Employe_EmployeId",
                table: "Vehicule",
                column: "EmployeId",
                principalTable: "Employe",
                principalColumn: "Id");
        }
    }
}
