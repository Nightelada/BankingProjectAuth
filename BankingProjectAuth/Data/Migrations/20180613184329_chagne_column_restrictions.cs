using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankingProjectAuth.Data.Migrations
{
    public partial class chagne_column_restrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SubscriptionNumber",
                table: "UtilityBill",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UtilityBill",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "BankingAccount",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MoneyTransfer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalReason = table.Column<string>(maxLength: 500, nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    BankingAccountID = table.Column<int>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(maxLength: 50, nullable: true),
                    RecipientAddress = table.Column<string>(maxLength: 255, nullable: true),
                    RecipientCountry = table.Column<string>(maxLength: 50, nullable: true),
                    RecipientIBAN = table.Column<string>(maxLength: 30, nullable: true),
                    RecipientName = table.Column<string>(maxLength: 255, nullable: true),
                    TransferDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransfer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MoneyTransfer_BankingAccount_BankingAccountID",
                        column: x => x.BankingAccountID,
                        principalTable: "BankingAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransfer_BankingAccountID",
                table: "MoneyTransfer",
                column: "BankingAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyTransfer");

            migrationBuilder.AlterColumn<string>(
                name: "SubscriptionNumber",
                table: "UtilityBill",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UtilityBill",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "BankingAccount",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
