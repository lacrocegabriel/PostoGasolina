using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostoGasolina.Infra.Migrations
{
    public partial class Enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combustiveis");

            migrationBuilder.RenameColumn(
                name: "TipoCombustivel",
                table: "Veiculos",
                newName: "IdTipoCombustivel");

            migrationBuilder.RenameColumn(
                name: "TipoCombustivel",
                table: "Abastecimentos",
                newName: "IdTipoCombustivel");

            migrationBuilder.CreateTable(
                name: "TipoCombustivel",
                columns: table => new
                {
                    IdTipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCombustivel", x => x.IdTipoCombustivel);
                });

            migrationBuilder.InsertData(
                table: "TipoCombustivel",
                columns: new[] { "IdTipoCombustivel", "Name" },
                values: new object[,]
                {
                    { 0, "Gasolina" },
                    { 1, "Etanol" },
                    { 2, "DieselS10" },
                    { 3, "DieselS500" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoCombustivel");

            migrationBuilder.RenameColumn(
                name: "IdTipoCombustivel",
                table: "Veiculos",
                newName: "TipoCombustivel");

            migrationBuilder.RenameColumn(
                name: "IdTipoCombustivel",
                table: "Abastecimentos",
                newName: "TipoCombustivel");

            migrationBuilder.CreateTable(
                name: "Combustiveis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustiveis", x => x.Id);
                });
        }
    }
}
