using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkEasyNBP.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class addoneoffcards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OneOffCardId",
                table: "Zones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OneOffCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeSelling = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Period = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneOffCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneOffCards_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zones_OneOffCardId",
                table: "Zones",
                column: "OneOffCardId");

            migrationBuilder.CreateIndex(
                name: "IX_OneOffCards_VehicleId",
                table: "OneOffCards",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_OneOffCards_OneOffCardId",
                table: "Zones",
                column: "OneOffCardId",
                principalTable: "OneOffCards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zones_OneOffCards_OneOffCardId",
                table: "Zones");

            migrationBuilder.DropTable(
                name: "OneOffCards");

            migrationBuilder.DropIndex(
                name: "IX_Zones_OneOffCardId",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "OneOffCardId",
                table: "Zones");
        }
    }
}
