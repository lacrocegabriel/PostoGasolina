using Microsoft.EntityFrameworkCore.Migrations;

namespace PostoGasolina.Infra.Migrations
{
    public partial class Litragem3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Litragem",
                table: "Abastecimentos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Litragem",
                table: "Abastecimentos",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
