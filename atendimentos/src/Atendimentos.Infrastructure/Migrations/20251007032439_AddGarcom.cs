using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atendimentos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGarcom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "MESAS",
                type: "RAW(2000)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "RAW(8)",
                oldRowVersion: true,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GARCONS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Matricula = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Ativo = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GARCONS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GARCONS");

            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "MESAS",
                type: "RAW(8)",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "RAW(2000)");
        }
    }
}
