using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kuhlschrank.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: false),
                    dateOfBirth = table.Column<DateTime>(nullable: false),
                    code = table.Column<string>(nullable: false),
                    place = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    phoneNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: false),
                    login = table.Column<string>(nullable: false),
                    password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fridge",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    serialNumber = table.Column<string>(maxLength: 10, nullable: false),
                    temperature = table.Column<float>(nullable: false),
                    activated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridge", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    NIP = table.Column<string>(nullable: false),
                    code = table.Column<string>(nullable: false),
                    place = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    difficulty = table.Column<int>(nullable: false),
                    vegetarian = table.Column<bool>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    time = table.Column<double>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    portions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    time = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ClientFridge",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fridgeid = table.Column<long>(nullable: false),
                    clientid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFridge", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClientFridge_Client_clientid",
                        column: x => x.clientid,
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFridge_Fridge_fridgeid",
                        column: x => x.fridgeid,
                        principalTable: "Fridge",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    code = table.Column<string>(nullable: false),
                    unit = table.Column<string>(nullable: true),
                    unitOne = table.Column<string>(nullable: true),
                    expirationDateOpen = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    producerid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Producer_producerid",
                        column: x => x.producerid,
                        principalTable: "Producer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryRecipe",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    clientid = table.Column<long>(nullable: false),
                    recipeid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryRecipe", x => x.id);
                    table.ForeignKey(
                        name: "FK_HistoryRecipe_Client_clientid",
                        column: x => x.clientid,
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryRecipe_Recipe_recipeid",
                        column: x => x.recipeid,
                        principalTable: "Recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    clientid = table.Column<long>(nullable: false),
                    fridgeid = table.Column<long>(nullable: false),
                    supplyid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_Client_clientid",
                        column: x => x.clientid,
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Fridge_fridgeid",
                        column: x => x.fridgeid,
                        principalTable: "Fridge",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Supply_supplyid",
                        column: x => x.supplyid,
                        principalTable: "Supply",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FridgeProduct",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<double>(nullable: false),
                    expirationDate = table.Column<DateTime>(nullable: false),
                    buyDate = table.Column<DateTime>(nullable: false),
                    fridgeid = table.Column<long>(nullable: false),
                    productid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_FridgeProduct_Fridge_fridgeid",
                        column: x => x.fridgeid,
                        principalTable: "Fridge",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeProduct_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryProduct",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(nullable: false),
                    clientid = table.Column<long>(nullable: false),
                    productid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_HistoryProduct_Client_clientid",
                        column: x => x.clientid,
                        principalTable: "Client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryProduct_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenProduct",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<double>(nullable: false),
                    expirationDate = table.Column<DateTime>(nullable: false),
                    OpenDate = table.Column<DateTime>(nullable: false),
                    returned = table.Column<bool>(nullable: false),
                    fridgeid = table.Column<long>(nullable: false),
                    productid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_OpenProduct_Fridge_fridgeid",
                        column: x => x.fridgeid,
                        principalTable: "Fridge",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenProduct_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeProduct",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<double>(nullable: false),
                    productid = table.Column<long>(nullable: false),
                    recipeid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_RecipeProduct_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeProduct_Recipe_recipeid",
                        column: x => x.recipeid,
                        principalTable: "Recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<double>(nullable: false),
                    orderid = table.Column<long>(nullable: false),
                    productid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_orderid",
                        column: x => x.orderid,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFridge_clientid",
                table: "ClientFridge",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFridge_fridgeid",
                table: "ClientFridge",
                column: "fridgeid");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProduct_fridgeid",
                table: "FridgeProduct",
                column: "fridgeid");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProduct_productid",
                table: "FridgeProduct",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryProduct_clientid",
                table: "HistoryProduct",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryProduct_productid",
                table: "HistoryProduct",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryRecipe_clientid",
                table: "HistoryRecipe",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryRecipe_recipeid",
                table: "HistoryRecipe",
                column: "recipeid");

            migrationBuilder.CreateIndex(
                name: "IX_OpenProduct_fridgeid",
                table: "OpenProduct",
                column: "fridgeid");

            migrationBuilder.CreateIndex(
                name: "IX_OpenProduct_productid",
                table: "OpenProduct",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_clientid",
                table: "Order",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_fridgeid",
                table: "Order",
                column: "fridgeid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_supplyid",
                table: "Order",
                column: "supplyid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_orderid",
                table: "OrderProduct",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_productid",
                table: "OrderProduct",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_producerid",
                table: "Product",
                column: "producerid");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProduct_productid",
                table: "RecipeProduct",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProduct_recipeid",
                table: "RecipeProduct",
                column: "recipeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFridge");

            migrationBuilder.DropTable(
                name: "FridgeProduct");

            migrationBuilder.DropTable(
                name: "HistoryProduct");

            migrationBuilder.DropTable(
                name: "HistoryRecipe");

            migrationBuilder.DropTable(
                name: "OpenProduct");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "RecipeProduct");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Fridge");

            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropTable(
                name: "Producer");
        }
    }
}
