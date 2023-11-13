using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackSwapApplication.Migrations
{
    /// <inheritdoc />
    public partial class TradeNormalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Trades_TradeId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Trades_TradeId1",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_TradeId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_TradeId1",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "TradeId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "TradeId1",
                table: "Cards");

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

            migrationBuilder.CreateIndex(
                name: "IX_TradeBuyerCards_TradeId",
                table: "TradeBuyerCards",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeSellerCards_TradeId",
                table: "TradeSellerCards",
                column: "TradeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeBuyerCards");

            migrationBuilder.DropTable(
                name: "TradeSellerCards");

            migrationBuilder.AddColumn<uint>(
                name: "TradeId",
                table: "Cards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "TradeId1",
                table: "Cards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TradeId",
                table: "Cards",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TradeId1",
                table: "Cards",
                column: "TradeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Trades_TradeId",
                table: "Cards",
                column: "TradeId",
                principalTable: "Trades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Trades_TradeId1",
                table: "Cards",
                column: "TradeId1",
                principalTable: "Trades",
                principalColumn: "Id");
        }
    }
}
