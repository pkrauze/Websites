using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebsitesProject.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Website",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Website_UserID",
                table: "Website",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserID",
                table: "Order",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Website_User_UserID",
                table: "Website",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Website_User_UserID",
                table: "Website");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Website_UserID",
                table: "Website");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Website");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Order");
        }
    }
}
