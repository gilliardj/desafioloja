using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MercadoEletronico.Loja.Infra.Migrations
{
    public partial class LojaInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    numero_pedido = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "itens_pedido",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    preco_unitario = table.Column<decimal>(type: "TEXT", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    PedidoID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itens_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_itens_pedido_pedidos_PedidoID",
                        column: x => x.PedidoID,
                        principalTable: "pedidos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_itens_pedido_PedidoID",
                table: "itens_pedido",
                column: "PedidoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itens_pedido");

            migrationBuilder.DropTable(
                name: "pedidos");
        }
    }
}