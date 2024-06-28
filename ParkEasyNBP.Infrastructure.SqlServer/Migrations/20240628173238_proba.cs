using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkEasyNBP.Infrastructure.SqlServer.Migrations
{
    public partial class proba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Uklanjanje postojeće kolone UserId1
            migrationBuilder.DropForeignKey(
                 name: "FK_Vehicles_AspNetUsers_UserId1",
                 table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserId1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Vehicles");

            // Dodavanje nove kolone UserId sa tipom nvarchar(450)
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "SubscriptionCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Penalties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "OneOffCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Controls",
                nullable: false,
                defaultValue: 0);

            // Kreiranje indeksa za nove kolone
            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
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

            // Dodavanje stranih ključeva
            migrationBuilder.AddForeignKey(
                name: "FK_Controls_Vehicles_VehicleId",
                table: "Controls",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OneOffCards_Vehicles_VehicleId",
                table: "OneOffCards",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Penalties_Vehicles_VehicleId",
                table: "Penalties",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionCards_Vehicles_VehicleId",
                table: "SubscriptionCards",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId",
                table: "Vehicles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Brisanje stranih ključeva
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

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId",
                table: "Vehicles");

            // Brisanje indeksa za nove kolone
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles");

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

            // Brisanje kolona
            migrationBuilder.DropColumn(
                name: "UserId",
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

            // Vraćanje kolone UserId1
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            // Vraćanje indeksa i stranih ključeva za UserId1
            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId1",
                table: "Vehicles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId1",
                table: "Vehicles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
