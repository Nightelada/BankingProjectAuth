using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankingProjectAuth.Data.Migrations
{
    public partial class change_account_table_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_User_UserID",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Account_BankingAccountID",
                table: "Card");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "BankingAccount");

            migrationBuilder.RenameIndex(
                name: "IX_Account_UserID",
                table: "BankingAccount",
                newName: "IX_BankingAccount_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankingAccount",
                table: "BankingAccount",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankingAccount_User_UserID",
                table: "BankingAccount",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Card_BankingAccount_BankingAccountID",
                table: "Card",
                column: "BankingAccountID",
                principalTable: "BankingAccount",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankingAccount_User_UserID",
                table: "BankingAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_BankingAccount_BankingAccountID",
                table: "Card");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankingAccount",
                table: "BankingAccount");

            migrationBuilder.RenameTable(
                name: "BankingAccount",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_BankingAccount_UserID",
                table: "Account",
                newName: "IX_Account_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "ID");

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
    }
}
