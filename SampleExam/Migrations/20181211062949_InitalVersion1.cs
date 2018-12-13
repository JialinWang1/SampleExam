using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleExam.Migrations
{
    public partial class InitalVersion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Population",
                table: "Planets",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Population",
                table: "Planets",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
