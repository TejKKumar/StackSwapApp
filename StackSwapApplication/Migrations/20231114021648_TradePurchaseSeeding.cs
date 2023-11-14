using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StackSwapApplication.Migrations
{
    /// <inheritdoc />
    public partial class TradePurchaseSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Purchases_PurchaseId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_PurchaseId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "PurchaseCards",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PurchaseId = table.Column<uint>(type: "INTEGER", nullable: false),
                    CardId = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseCards_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Credits", "Email", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1u, 2755u, "bgorthy@gmail.com", "Ben Gorthy", "beng1", "Dovaquila" },
                    { 2u, 1500u, "nKamal@gmail.com", "Nafee Kamal", "nKamal2", "Zangun" },
                    { 3u, 5500u, "jhunter@gmail.com", "Jennifer Hunter", "jHunter3", "VioletJen" },
                    { 4u, 500u, "jyang@gmail.com", "Joyce Yang", "jYang5", "JuicyJ" },
                    { 5u, 5500u, "jnguyen@gmail.com", "Jenny Nguyen", "jjNguy", "J-Wizzy" },
                    { 6u, 17500u, "jjohng@gmail.com", "Johnathan Graham", "jGraham2", "JonJonQ" },
                    { 7u, 175u, "shazadU@gmail.com", "Umair Shazad", "umRick22", "BigRick" },
                    { 8u, 350u, "sgangnon@gmail.com", "Shannon Gangnon", "sh559", "Shananigans" },
                    { 9u, 1255u, "miaCIA@gmail.com", "Mia Cia", "miaCy55", "CiayteMi" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CardTier", "Champion", "Damage", "Health", "Magic", "OwnerID" },
                values: new object[,]
                {
                    { 1u, 1, "Ashe", 1250.0, 800.0, 1500.0, 1u },
                    { 2u, 2, "Ashe", 1300.0, 850.0, 1550.0, 1u },
                    { 3u, 1, "Draven", 3550.0, 2800.0, 500.0, 1u },
                    { 4u, 5, "Urgot", 5250.0, 900.0, 7500.0, 1u },
                    { 5u, 5, "Draven", 4025.0, 5800.0, 2500.0, 2u },
                    { 6u, 2, "Jarvan", 3200.0, 2800.0, 4500.0, 2u },
                    { 7u, 2, "Ashe", 1300.0, 850.0, 1550.0, 3u },
                    { 8u, 5, "Jax", 1300.0, 1850.0, 4550.0, 4u },
                    { 9u, 4, "Olaf", 6550.0, 3800.0, 500.0, 4u },
                    { 10u, 4, "Tarin", 1250.0, 1900.0, 7500.0, 4u },
                    { 11u, 5, "Jax", 1300.0, 1850.0, 4550.0, 5u },
                    { 12u, 1, "Draven", 3550.0, 2800.0, 500.0, 5u },
                    { 13u, 2, "Jarvan", 3200.0, 2800.0, 4500.0, 6u },
                    { 14u, 2, "Ashe", 1300.0, 850.0, 1550.0, 6u },
                    { 15u, 5, "Jax", 1300.0, 1850.0, 4550.0, 7u },
                    { 16u, 4, "Olaf", 6550.0, 3800.0, 500.0, 7u },
                    { 17u, 4, "Tarin", 1250.0, 1900.0, 7500.0, 7u },
                    { 18u, 5, "Jax", 1300.0, 1850.0, 4550.0, 7u },
                    { 19u, 1, "Draven", 3550.0, 2800.0, 500.0, 7u },
                    { 20u, 5, "Darius", 7300.0, 2850.0, 750.0, 8u },
                    { 21u, 4, "A", 550.0, 7800.0, 3500.0, 8u },
                    { 22u, 4, "Olaf", 6550.0, 3800.0, 500.0, 9u },
                    { 23u, 4, "Tarin", 1250.0, 1900.0, 7500.0, 9u },
                    { 24u, 5, "Jax", 1300.0, 1850.0, 4550.0, 9u }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "BuyerId", "PurchaseDate" },
                values: new object[] { 1u, 5u, new DateTime(2020, 5, 1, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "BuyerId", "SellerId", "TradeDate" },
                values: new object[] { 1u, 7u, 9u, new DateTime(2023, 7, 12, 22, 20, 4, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PurchaseCards",
                columns: new[] { "Id", "CardId", "PurchaseId" },
                values: new object[] { 1u, 11u, 1u });

            migrationBuilder.InsertData(
                table: "TradeBuyerCards",
                columns: new[] { "Id", "BuyerId", "CardId", "TradeId" },
                values: new object[,]
                {
                    { 1u, 7u, 24u, 1u },
                    { 2u, 7u, 23u, 1u }
                });

            migrationBuilder.InsertData(
                table: "TradeSellerCards",
                columns: new[] { "Id", "CardId", "SellerId", "TradeId" },
                values: new object[] { 1u, 15u, 9u, 1u });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseCards_PurchaseId",
                table: "PurchaseCards",
                column: "PurchaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseCards");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 5u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 6u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 7u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 8u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 9u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 10u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 11u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 12u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 13u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 14u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 15u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 18u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 20u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 21u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 22u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 23u);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 24u);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "TradeBuyerCards",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "TradeBuyerCards",
                keyColumn: "Id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "TradeSellerCards",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7u);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9u);

            migrationBuilder.AddColumn<uint>(
                name: "PurchaseId",
                table: "Cards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PurchaseId",
                table: "Cards",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Purchases_PurchaseId",
                table: "Cards",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id");
        }
    }
}
