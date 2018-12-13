using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleExam.Migrations
{
    public partial class EFVersioon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Planet",
                table: "SpaceShip");

            migrationBuilder.AddColumn<long>(
                name: "PlanetID",
                table: "SpaceShip",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpaceShip_PlanetID",
                table: "SpaceShip",
                column: "PlanetID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceShip_Planets_PlanetID",
                table: "SpaceShip",
                column: "PlanetID",
                principalTable: "Planets",
                principalColumn: "PlanetID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceShip_Planets_PlanetID",
                table: "SpaceShip");

            migrationBuilder.DropIndex(
                name: "IX_SpaceShip_PlanetID",
                table: "SpaceShip");

            migrationBuilder.DropColumn(
                name: "PlanetID",
                table: "SpaceShip");

            migrationBuilder.AddColumn<string>(
                name: "Planet",
                table: "SpaceShip",
                nullable: true);
        }
    }
}
