using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodTimes.Migrations
{
    public partial class webDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Prijs",
                table: "product",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Prijs",
                table: "product",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
