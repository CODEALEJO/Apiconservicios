using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ejemploApiConServicios.Migrations
{
    /// <inheritdoc />
    public partial class Seeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "id", "branch", "color", "model", "price", "year" },
                values: new object[,]
                {
                    { 1, "Toyota", "black", "Corolla", 100.0, 2022 },
                    { 2, "Honda", "white", "Civic", 200.0, 2021 },
                    { 3, "Ford", "red", "Mustang", 300.0, 2023 },
                    { 11, "Nissan", "blue", "Leaf", 150.0, 2020 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "name", "password" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Administrador", "$2a$11$d8Pv2B.KO2S1L7mIup6ERewEHEKXu2VY0wG.MfGgMh0TD4wHqHNgW" },
                    { 2, "user@example.com", "Usuario Normal", "$2a$11$pdoIOFIO8.LV5liWSZv6..Igxsw5f.Y34sI9g.JPCyU9QSiD70Xaq" },
                    { 3, "anonymous@example.com", "Usuario Anónimo", "$2a$11$.8DVkpLtNfVUIFDiKCVWdeo1UvghvWeH7dTMQrGYsX9qa0kn/4ASq" },
                    { 4, "invite@example.com", "Usuario Invitado", "$2a$11$nC1vB0SbmTzDfD7ViX2b0OmsOZZkzRz2fbZIWn0OIIzsZq1hvZoW2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
