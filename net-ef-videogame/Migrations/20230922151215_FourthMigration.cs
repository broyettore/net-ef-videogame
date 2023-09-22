using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_software_houses_SoftwarehouseSoftwareId",
                table: "videogame");

            migrationBuilder.DropIndex(
                name: "IX_videogame_SoftwarehouseSoftwareId",
                table: "videogame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_software_houses",
                table: "software_houses");

            migrationBuilder.DropColumn(
                name: "SoftwarehouseSoftwareId",
                table: "videogame");

            migrationBuilder.RenameTable(
                name: "software_houses",
                newName: "softwarehouses");

            migrationBuilder.RenameColumn(
                name: "SoftwareId",
                table: "videogame",
                newName: "SoftwareHouseId");

            migrationBuilder.RenameColumn(
                name: "SoftwareId",
                table: "softwarehouses",
                newName: "SoftwareHouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_softwarehouses",
                table: "softwarehouses",
                column: "SoftwareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_videogame_SoftwareHouseId",
                table: "videogame",
                column: "SoftwareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_softwarehouses_SoftwareHouseId",
                table: "videogame",
                column: "SoftwareHouseId",
                principalTable: "softwarehouses",
                principalColumn: "SoftwareHouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_softwarehouses_SoftwareHouseId",
                table: "videogame");

            migrationBuilder.DropIndex(
                name: "IX_videogame_SoftwareHouseId",
                table: "videogame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_softwarehouses",
                table: "softwarehouses");

            migrationBuilder.RenameTable(
                name: "softwarehouses",
                newName: "software_houses");

            migrationBuilder.RenameColumn(
                name: "SoftwareHouseId",
                table: "videogame",
                newName: "SoftwareId");

            migrationBuilder.RenameColumn(
                name: "SoftwareHouseId",
                table: "software_houses",
                newName: "SoftwareId");

            migrationBuilder.AddColumn<long>(
                name: "SoftwarehouseSoftwareId",
                table: "videogame",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_software_houses",
                table: "software_houses",
                column: "SoftwareId");

            migrationBuilder.CreateIndex(
                name: "IX_videogame_SoftwarehouseSoftwareId",
                table: "videogame",
                column: "SoftwarehouseSoftwareId");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_software_houses_SoftwarehouseSoftwareId",
                table: "videogame",
                column: "SoftwarehouseSoftwareId",
                principalTable: "software_houses",
                principalColumn: "SoftwareId");
        }
    }
}
