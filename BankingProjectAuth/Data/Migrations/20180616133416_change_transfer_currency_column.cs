using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankingProjectAuth.Data.Migrations
{
    public partial class change_transfer_currency_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "MoneyTransfer");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyID",
                table: "MoneyTransfer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransfer_CurrencyID",
                table: "MoneyTransfer",
                column: "CurrencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransfer_Currency_CurrencyID",
                table: "MoneyTransfer",
                column: "CurrencyID",
                principalTable: "Currency",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransfer_Currency_CurrencyID",
                table: "MoneyTransfer");

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransfer_CurrencyID",
                table: "MoneyTransfer");

            migrationBuilder.DropColumn(
                name: "CurrencyID",
                table: "MoneyTransfer");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "MoneyTransfer",
                nullable: true);
        }
    }
}
