using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StackSwapApplication.Migrations
{
    /// <inheritdoc />
    public partial class TradeNormalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Credits = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Champion = table.Column<string>(type: "TEXT", nullable: true),
                    CardTier = table.Column<int>(type: "INTEGER", nullable: false),
                    Damage = table.Column<double>(type: "REAL", nullable: false),
                    Magic = table.Column<double>(type: "REAL", nullable: false),
                    Health = table.Column<double>(type: "REAL", nullable: false),
                    OwnerID = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuyerId = table.Column<uint>(type: "INTEGER", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SellerId = table.Column<uint>(type: "INTEGER", nullable: false),
                    BuyerId = table.Column<uint>(type: "INTEGER", nullable: false),
                    TradeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsAccepted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trades_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trades_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "TradeBuyerCards",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TradeId = table.Column<uint>(type: "INTEGER", nullable: false),
                    BuyerId = table.Column<uint>(type: "INTEGER", nullable: false),
                    CardId = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeBuyerCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradeBuyerCards_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradeSellerCards",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TradeId = table.Column<uint>(type: "INTEGER", nullable: false),
                    SellerId = table.Column<uint>(type: "INTEGER", nullable: false),
                    CardId = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeSellerCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradeSellerCards_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
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
                columns: new[] { "Id", "BuyerId", "IsAccepted", "IsComplete", "SellerId", "TradeDate" },
                values: new object[] { 1u, 7u, true, true, 9u, new DateTime(2023, 7, 12, 22, 20, 4, 0, DateTimeKind.Unspecified) });

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
                name: "IX_Cards_OwnerID",
                table: "Cards",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseCards_PurchaseId",
                table: "PurchaseCards",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BuyerId",
                table: "Purchases",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeBuyerCards_TradeId",
                table: "TradeBuyerCards",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_BuyerId",
                table: "Trades",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_SellerId",
                table: "Trades",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeSellerCards_TradeId",
                table: "TradeSellerCards",
                column: "TradeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "PurchaseCards");

            migrationBuilder.DropTable(
                name: "TradeBuyerCards");

            migrationBuilder.DropTable(
                name: "TradeSellerCards");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
