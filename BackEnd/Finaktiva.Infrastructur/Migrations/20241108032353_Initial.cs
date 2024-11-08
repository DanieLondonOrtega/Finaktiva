using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finaktiva.Infrastructur.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeEventLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEventLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLogs_TypeEventLogs_IdType",
                        column: x => x.IdType,
                        principalTable: "TypeEventLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypeEventLogs",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Api" });

            migrationBuilder.InsertData(
                table: "TypeEventLogs",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Formulario" });

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_IdType",
                table: "EventLogs",
                column: "IdType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "TypeEventLogs");
        }
    }
}
