﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission09_murdodav.Migrations
{
    public partial class AddBookPurchasesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookPurchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPurchases", x => x.PurchaseId);
                });

            //migrationBuilder.CreateTable(
            //    name: "Books",
            //    columns: table => new
            //    {
            //        BookId = table.Column<long>(nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Title = table.Column<string>(nullable: false),
            //        Author = table.Column<string>(nullable: false),
            //        Publisher = table.Column<string>(nullable: false),
            //        Isbn = table.Column<string>(nullable: false),
            //        Classification = table.Column<string>(nullable: false),
            //        Category = table.Column<string>(nullable: false),
            //        PageCount = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Books", x => x.BookId);
            //    });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    BookPurchasePurchaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_CartItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_BookPurchases_BookPurchasePurchaseId",
                        column: x => x.BookPurchasePurchaseId,
                        principalTable: "BookPurchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_BookId",
                table: "CartItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_BookPurchasePurchaseId",
                table: "CartItem",
                column: "BookPurchasePurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookPurchases");
        }
    }
}
