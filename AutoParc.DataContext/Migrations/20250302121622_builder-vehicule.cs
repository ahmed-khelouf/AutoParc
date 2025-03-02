using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoParc.DataContext.Migrations
{
    public partial class buildervehicule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicule",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmployeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vehicule",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmployeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vehicule",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmployeId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vehicule",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmployeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Vehicule",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmployeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Vehicule",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmployeId",
                value: null);
        }
    }
}
