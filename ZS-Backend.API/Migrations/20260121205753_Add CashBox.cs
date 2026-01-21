using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZS_Backend.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCashBox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "CashBoxId",
                table: "Transactions",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "CashBoxes",
                columns: table => new
                {
                    Id = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OpenedAt = table.Column<TimeOnly>(type: "time", nullable: false),
                    ClosedAt = table.Column<TimeOnly>(type: "time", nullable: true),
                    OpeningBalance = table.Column<double>(type: "float", nullable: false),
                    ClosingBalance = table.Column<double>(type: "float", nullable: true),
                    AttendantName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBoxes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CashBoxId",
                table: "Transactions",
                column: "CashBoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CashBoxes_CashBoxId",
                table: "Transactions",
                column: "CashBoxId",
                principalTable: "CashBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CashBoxes_CashBoxId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "CashBoxes");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CashBoxId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CashBoxId",
                table: "Transactions");
        }
    }
}
