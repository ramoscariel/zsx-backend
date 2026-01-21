using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZS_Backend.API.Migrations
{
    /// <inheritdoc />
    public partial class AddLockers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lockers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastAssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastAssignedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lockers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lockers_Clients_LastAssignedTo",
                        column: x => x.LastAssignedTo,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Lockers",
                columns: new[] { "Id", "Available", "LastAssignedAt", "LastAssignedTo", "Notes" },
                values: new object[,]
                {
                    { "10H", true, null, null, null },
                    { "10M", true, null, null, null },
                    { "11H", true, null, null, null },
                    { "11M", true, null, null, null },
                    { "12H", true, null, null, null },
                    { "12M", true, null, null, null },
                    { "13H", true, null, null, null },
                    { "13M", true, null, null, null },
                    { "14H", true, null, null, null },
                    { "14M", true, null, null, null },
                    { "15H", true, null, null, null },
                    { "15M", true, null, null, null },
                    { "16H", true, null, null, null },
                    { "16M", true, null, null, null },
                    { "1H", true, null, null, null },
                    { "1M", true, null, null, null },
                    { "2H", true, null, null, null },
                    { "2M", true, null, null, null },
                    { "3H", true, null, null, null },
                    { "3M", true, null, null, null },
                    { "4H", true, null, null, null },
                    { "4M", true, null, null, null },
                    { "5H", true, null, null, null },
                    { "5M", true, null, null, null },
                    { "6H", true, null, null, null },
                    { "6M", true, null, null, null },
                    { "7H", true, null, null, null },
                    { "7M", true, null, null, null },
                    { "8H", true, null, null, null },
                    { "8M", true, null, null, null },
                    { "9H", true, null, null, null },
                    { "9M", true, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lockers_LastAssignedTo",
                table: "Lockers",
                column: "LastAssignedTo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lockers");
        }
    }
}
