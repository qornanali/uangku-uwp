using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Uangku_UWP.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    itemId = table.Column<Guid>(nullable: false),
                    amount = table.Column<double>(nullable: false),
                    dateTime = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    itemType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.itemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Item");
        }
    }
}
