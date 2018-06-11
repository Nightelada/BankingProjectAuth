using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankingProjectAuth.Data.Migrations
{
    public partial class change_one_letter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Account_AccountId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AspNetUsers",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AccountID");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Account_AccountID",
                table: "AspNetUsers",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Account_AccountID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "AspNetUsers",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AccountID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AccountId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Account_AccountId",
                table: "AspNetUsers",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
