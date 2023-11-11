using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StackSwapApplication.Migrations
{
    /// <inheritdoc />
    public partial class TradeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

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

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SellerId = table.Column<uint>(type: "INTEGER", nullable: false),
                    BuyerId = table.Column<uint>(type: "INTEGER", nullable: false),
                    TradeDate = table.Column<DateTime>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TradeId",
                table: "Cards",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TradeId1",
                table: "Cards",
                column: "TradeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_BuyerId",
                table: "Trades",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_SellerId",
                table: "Trades",
                column: "SellerId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Trades_TradeId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Trades_TradeId1",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "Trades");

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

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
