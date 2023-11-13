using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StackSwapApplication.Migrations
{
    /// <inheritdoc />
    public partial class SeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Credits", "Email", "Name", "Password", "UserName" },
                values: new object[,]
                {
                    { 1L, 775L, "beng@hotmail.com", "Ben Gorthy", "beng1", "DovAquila" },
                    { 2L, 650L, "joycey@hotmail.com", "Joyce Yang", "joycey2", "JuicyJ" },
                    { 3L, 250L, "jennyn@hotmail.com", "Jenny Nguyen", "jennyn3", "Jennay" },
                    { 4L, 550L, "jenh@hotmail.com", "Jennifer Hunter", "jenh4", "ViolentJen" },
                    { 5L, 1250L, "nafeek@hotmail.com", "Nafee Kamal", "nafeek5", "Zangun" },
                    { 6L, 700L, "jong@hotmail.com", "Johnathan Graham", "johng6", "TimberWood" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CardTier", "Champion", "Damage", "Health", "Magic", "OwnerID" },
                values: new object[,]
                {
                    { 1L, 2, "Ashe", 900.0, 1200.0, 320.0, 1L },
                    { 2L, 4, "Jayce", 1500.0, 900.0, 150.0, 1L },
                    { 3L, 4, "Ahri", 1345.0, 900.0, 1256.0, 1L },
                    { 4L, 1, "Aatrox", 250.0, 1250.0, 825.0, 1L },
                    { 5L, 5, "Jayce", 1550.0, 950.0, 200.0, 1L },
                    { 6L, 3, "Draven", 2250.0, 1250.0, 200.0, 2L },
                    { 7L, 3, "Darius", 2575.0, 1750.0, 300.0, 2L },
                    { 8L, 2, "Jinx", 1250.0, 900.0, 550.0, 2L },
                    { 9L, 3, "Draven", 2250.0, 1250.0, 200.0, 3L },
                    { 10L, 1, "Pyke", 895.0, 2500.0, 560.0, 3L },
                    { 11L, 5, "Sion", 6250.0, 1200.0, 550.0, 3L },
                    { 12L, 5, "Talon", 1255.0, 950.0, 235.0, 3L },
                    { 13L, 2, "Jinx", 1250.0, 900.0, 550.0, 3L },
                    { 14L, 3, "Draven", 2250.0, 1250.0, 200.0, 4L },
                    { 15L, 1, "Pyke", 895.0, 2500.0, 560.0, 4L },
                    { 16L, 5, "Sion", 6250.0, 1200.0, 550.0, 4L },
                    { 17L, 5, "Talon", 1255.0, 950.0, 235.0, 4L },
                    { 18L, 2, "Jinx", 1250.0, 900.0, 550.0, 4L },
                    { 19L, 2, "Ashe", 900.0, 1200.0, 320.0, 5L },
                    { 20L, 4, "Jayce", 1500.0, 900.0, 150.0, 5L },
                    { 21L, 4, "Ahri", 1345.0, 900.0, 1256.0, 5L },
                    { 22L, 5, "Sion", 6250.0, 1200.0, 550.0, 5L },
                    { 23L, 5, "Talon", 1255.0, 950.0, 235.0, 5L },
                    { 24L, 2, "Jinx", 1250.0, 900.0, 550.0, 5L },
                    { 25L, 2, "Jinx", 1250.0, 900.0, 550.0, 6L },
                    { 26L, 4, "Jayce", 1500.0, 900.0, 150.0, 6L },
                    { 27L, 4, "Ahri", 1345.0, 900.0, 1256.0, 6L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
