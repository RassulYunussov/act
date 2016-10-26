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
                    ClientBin = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DocumentNumber = table.Column<int>(nullable: false),
                    SupplierBin = table.Column<string>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acts");
        }
    }
}
