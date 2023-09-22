using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "software_houses",
                columns: table => new
                {
                    SoftwareId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tax_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_software_houses", x => x.SoftwareId);
                });

            migrationBuilder.CreateTable(
                name: "videogame",
                columns: table => new
                {
                    VideogameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Software_house_id = table.Column<long>(type: "bigint", nullable: false),
                    SoftwareId = table.Column<long>(type: "bigint", nullable: false),
                    SoftwarehouseSoftwareId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videogame", x => x.VideogameId);
                    table.ForeignKey(
                        name: "FK_videogame_software_houses_SoftwarehouseSoftwareId",
                        column: x => x.SoftwarehouseSoftwareId,
                        principalTable: "software_houses",
                        principalColumn: "SoftwareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_videogame_SoftwarehouseSoftwareId",
                table: "videogame",
                column: "SoftwarehouseSoftwareId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "videogame");

            migrationBuilder.DropTable(
                name: "software_houses");
        }
    }
}
