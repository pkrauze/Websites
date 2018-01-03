using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebsitesProject.Migrations
{
    public partial class AddOrderIDToWebsite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Website_Order_OrderID",
                table: "Website");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "Website",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Website_Order_OrderID",
                table: "Website",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Website_Order_OrderID",
                table: "Website");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "Website",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Website_Order_OrderID",
                table: "Website",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
