using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkEasyNBP.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class proba3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

           /* migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "SubscriptionCards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Penalties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "OneOffCards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Controls",
                type: "int",
                nullable: true);*/

            /*migrationBuilder.CreateIndex(
                name: "IX_SubscriptionCards_VehicleId",
                table: "SubscriptionCards",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_VehicleId",
                table: "Penalties",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_OneOffCards_VehicleId",
                table: "OneOffCards",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Controls_VehicleId",
                table: "Controls",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VehicleId",
                table: "AspNetUsers",
                column: "VehicleId",
                unique: true,
                filter: "[VehicleId] IS NOT NULL");
            */
            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Vehicles_VehicleId",
                table: "AspNetUsers",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            /*migrationBuilder.AddForeignKey(
                name: "FK_Controls_Vehicles_VehicleId",
                table: "Controls",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OneOffCards_Vehicles_VehicleId",
                table: "OneOffCards",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalties_Vehicles_VehicleId",
                table: "Penalties",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionCards_Vehicles_VehicleId",
                table: "SubscriptionCards",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Vehicles_VehicleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Controls_Vehicles_VehicleId",
                table: "Controls");

            migrationBuilder.DropForeignKey(
                name: "FK_OneOffCards_Vehicles_VehicleId",
                table: "OneOffCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalties_Vehicles_VehicleId",
                table: "Penalties");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionCards_Vehicles_VehicleId",
                table: "SubscriptionCards");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionCards_VehicleId",
                table: "SubscriptionCards");

            migrationBuilder.DropIndex(
                name: "IX_Penalties_VehicleId",
                table: "Penalties");

            migrationBuilder.DropIndex(
                name: "IX_OneOffCards_VehicleId",
                table: "OneOffCards");

            migrationBuilder.DropIndex(
                name: "IX_Controls_VehicleId",
                table: "Controls");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VehicleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "SubscriptionCards");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Penalties");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "OneOffCards");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Controls");
        }
    }
}
