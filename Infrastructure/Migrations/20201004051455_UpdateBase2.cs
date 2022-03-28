using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateBase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "TB_COMPRA_USUARIO",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCompra",
                table: "TB_COMPRA_USUARIO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_COMPRA",
                columns: table => new
                {
                    COM_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COM_ESTADO = table.Column<int>(nullable: false),
                    COM_DATA_COMPRA = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COMPRA", x => x.COM_ID);
                    table.ForeignKey(
                        name: "FK_TB_COMPRA_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMPRA_USUARIO_CompraId",
                table: "TB_COMPRA_USUARIO",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMPRA_UserId",
                table: "TB_COMPRA",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_COMPRA_USUARIO_TB_COMPRA_CompraId",
                table: "TB_COMPRA_USUARIO",
                column: "CompraId",
                principalTable: "TB_COMPRA",
                principalColumn: "COM_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_COMPRA_USUARIO_TB_COMPRA_CompraId",
                table: "TB_COMPRA_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_COMPRA");

            migrationBuilder.DropIndex(
                name: "IX_TB_COMPRA_USUARIO_CompraId",
                table: "TB_COMPRA_USUARIO");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "TB_COMPRA_USUARIO");

            migrationBuilder.DropColumn(
                name: "IdCompra",
                table: "TB_COMPRA_USUARIO");
        }
    }
}
