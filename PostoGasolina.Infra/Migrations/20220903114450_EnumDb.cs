using Microsoft.EntityFrameworkCore.Migrations;

namespace PostoGasolina.Infra.Migrations
{
    public partial class EnumDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTipoCombustivel",
                table: "Veiculos",
                newName: "TipoCombustivelId");

            migrationBuilder.RenameColumn(
                name: "IdTipoCombustivel",
                table: "Abastecimentos",
                newName: "TipoCombustivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_TipoCombustivelId",
                table: "Veiculos",
                column: "TipoCombustivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Abastecimentos_TipoCombustivelId",
                table: "Abastecimentos",
                column: "TipoCombustivelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abastecimentos_TipoCombustivel_TipoCombustivelId",
                table: "Abastecimentos",
                column: "TipoCombustivelId",
                principalTable: "TipoCombustivel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_TipoCombustivel_TipoCombustivelId",
                table: "Veiculos",
                column: "TipoCombustivelId",
                principalTable: "TipoCombustivel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abastecimentos_TipoCombustivel_TipoCombustivelId",
                table: "Abastecimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_TipoCombustivel_TipoCombustivelId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_TipoCombustivelId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Abastecimentos_TipoCombustivelId",
                table: "Abastecimentos");

            migrationBuilder.RenameColumn(
                name: "TipoCombustivelId",
                table: "Veiculos",
                newName: "IdTipoCombustivel");

            migrationBuilder.RenameColumn(
                name: "TipoCombustivelId",
                table: "Abastecimentos",
                newName: "IdTipoCombustivel");
        }
    }
}
