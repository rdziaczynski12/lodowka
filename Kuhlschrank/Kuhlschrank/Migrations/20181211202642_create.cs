using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kuhlschrank.Migrations
{
    public partial class create : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_ClientFridge_clientid",
                table: "ClientFridge",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFridge_fridgeid",
                table: "ClientFridge",
                column: "fridgeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFridge");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Fridge");
        }
    }
}
