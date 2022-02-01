--
-- File generated with SQLiteStudio v3.3.3 on ter fev 1 08:26:01 2022
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: __EFMigrationsHistory
CREATE TABLE "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20220201112419_LojaInicio', '5.0.13');

-- Table: itens_pedido
CREATE TABLE "itens_pedido" (
    "id" TEXT NOT NULL CONSTRAINT "PK_itens_pedido" PRIMARY KEY,
    "descricao" TEXT NOT NULL,
    "preco_unitario" TEXT NOT NULL,
    "quantidade" INTEGER NOT NULL,
    "PedidoID" TEXT NOT NULL,
    CONSTRAINT "FK_itens_pedido_pedidos_PedidoID" FOREIGN KEY ("PedidoID") REFERENCES "pedidos" ("id")
);

-- Table: pedidos
CREATE TABLE "pedidos" (
    "id" TEXT NOT NULL CONSTRAINT "PK_pedidos" PRIMARY KEY,
    "numero_pedido" TEXT NOT NULL
);

-- Index: IX_itens_pedido_PedidoID
CREATE INDEX "IX_itens_pedido_PedidoID" ON "itens_pedido" ("PedidoID");

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
