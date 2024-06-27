using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkEasyNBP.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zones_OneOffCards_OneOffCardId",
                table: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_Zones_OneOffCardId",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "OneOffCardId",
                table: "Zones");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "OneOffCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "OneOffCards");

            migrationBuilder.AddColumn<int>(
                name: "OneOffCardId",
                table: "Zones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zones_OneOffCardId",
                table: "Zones",
                column: "OneOffCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_OneOffCards_OneOffCardId",
                table: "Zones",
                column: "OneOffCardId",
                principalTable: "OneOffCards",
                principalColumn: "Id");
        }
    }
}
