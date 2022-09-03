using Microsoft.EntityFrameworkCore.Migrations;

namespace PostoGasolina.Infra.Migrations
{
    public partial class EnumDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TipoCombustivel",
                newName: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "TipoCombustivel",
                newName: "Name");
        }
    }
}
