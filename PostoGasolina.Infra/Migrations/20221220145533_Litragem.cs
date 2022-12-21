using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostoGasolina.Infra.Migrations
{
    public partial class Litragem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Clientes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "Litragem",
                table: "Abastecimentos",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Litragem",
                table: "Abastecimentos",
                type: "real",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");
        }
    }
}
