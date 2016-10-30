using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace act.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AgreementDate = table.Column<DateTime>(nullable: false),
                    AgreementNumber = table.Column<uint>(nullable: false),
                    AgreementPrefix = table.Column<string>(nullable: true),
                    ClientBin = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DocumentNumber = table.Column<int>(nullable: true),
                    SupplierBin = table.Column<string>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Measure = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ScienceDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ActId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActServices_Acts_ActId",
                        column: x => x.ActId,
                        principalTable: "Acts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActServices_ActId",
                table: "ActServices",
                column: "ActId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActServices");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Acts");
        }
    }
}
