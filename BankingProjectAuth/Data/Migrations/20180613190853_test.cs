using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankingProjectAuth.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "BankingAccount");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyID",
                table: "BankingAccount",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankingAccount_CurrencyID",
                table: "BankingAccount",
                column: "CurrencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankingAccount_Currency_CurrencyID",
                table: "BankingAccount",
                column: "CurrencyID",
                principalTable: "Currency",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankingAccount_Currency_CurrencyID",
                table: "BankingAccount");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_BankingAccount_CurrencyID",
                table: "BankingAccount");

            migrationBuilder.DropColumn(
                name: "CurrencyID",
                table: "BankingAccount");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "BankingAccount",
                maxLength: 30,
                nullable: true);
        }
    }
}
