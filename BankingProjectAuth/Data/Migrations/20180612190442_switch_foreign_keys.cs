using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankingProjectAuth.Data.Migrations
{
    public partial class switch_foreign_keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Account_AccountID",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Account_AccountID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AccountID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Card",
                newName: "BankingAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Card_AccountID",
                table: "Card",
                newName: "IX_Card_BankingAccountID");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserID",
                table: "Account",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_UserID",
                table: "Account",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Account_BankingAccountID",
                table: "Card",
                column: "BankingAccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_User_UserID",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Account_BankingAccountID",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Account_UserID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "BankingAccountID",
                table: "Card",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Card_BankingAccountID",
                table: "Card",
                newName: "IX_Card_AccountID");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountID",
                table: "User",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Account_AccountID",
                table: "Card",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Account_AccountID",
                table: "User",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
