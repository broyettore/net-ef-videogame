using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_software_houses_SoftwarehouseSoftwareId",
                table: "videogame");

            migrationBuilder.AlterColumn<long>(
                name: "SoftwarehouseSoftwareId",
                table: "videogame",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_software_houses_SoftwarehouseSoftwareId",
                table: "videogame",
                column: "SoftwarehouseSoftwareId",
                principalTable: "software_houses",
                principalColumn: "SoftwareId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogame_software_houses_SoftwarehouseSoftwareId",
                table: "videogame");

            migrationBuilder.AlterColumn<long>(
                name: "SoftwarehouseSoftwareId",
                table: "videogame",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_videogame_software_houses_SoftwarehouseSoftwareId",
                table: "videogame",
                column: "SoftwarehouseSoftwareId",
                principalTable: "software_houses",
                principalColumn: "SoftwareId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
