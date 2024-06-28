using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkEasyNBP.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class proba5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropForeignKey(
                name: "FK_Controls_Vehicles_VehicleId",
                table: "Controls");

            migrationBuilder.DropForeignKey(
                name: "FK_OneOffCards_Vehicles_VehicleId",
                table: "OneOffCards");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionCards_Vehicles_VehicleId",
                table: "SubscriptionCards");
           */
            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "SubscriptionCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "OneOffCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Controls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_SubscriptionCards_Vehicles_VehicleId",
                table: "SubscriptionCards",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controls_Vehicles_VehicleId",
                table: "Controls");

            migrationBuilder.DropForeignKey(
                name: "FK_OneOffCards_Vehicles_VehicleId",
                table: "OneOffCards");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionCards_Vehicles_VehicleId",
                table: "SubscriptionCards");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "SubscriptionCards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "OneOffCards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Controls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
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
                name: "FK_SubscriptionCards_Vehicles_VehicleId",
                table: "SubscriptionCards",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
