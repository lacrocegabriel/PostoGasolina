using Microsoft.EntityFrameworkCore.Migrations;

namespace PostoGasolina.Infra.Migrations
{
    public partial class EnumTipoCombustivelFlex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipoCombustivel",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Flex" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoCombustivel",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
