using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkEasyNBP.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class uservehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Zones_ZoneId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ZoneId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Namee",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VehicleId",
                table: "AspNetUsers",
                column: "VehicleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Vehicles_VehicleId",
                table: "AspNetUsers",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Vehicles_VehicleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VehicleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Namee",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ZoneId",
                table: "AspNetUsers",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Zones_ZoneId",
                table: "AspNetUsers",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id");
        }
    }
}
