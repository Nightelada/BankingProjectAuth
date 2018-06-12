using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankingProjectAuth.Data.Migrations
{
    public partial class add_credit_and_utility_bill_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankingAccountID = table.Column<int>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    InstallmentAmmount = table.Column<decimal>(type: "money", nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    LastInstallment = table.Column<DateTime>(nullable: false),
                    NextInstallment = table.Column<DateTime>(nullable: false),
                    OverdueInterest = table.Column<decimal>(type: "money", nullable: false),
                    OverduePrincipal = table.Column<decimal>(type: "money", nullable: false),
                    OverdueTaxes = table.Column<decimal>(type: "money", nullable: false),
                    OwedInterest = table.Column<decimal>(type: "money", nullable: false),
                    OwedPrincipal = table.Column<decimal>(type: "money", nullable: false),
                    OwedTaxes = table.Column<decimal>(type: "money", nullable: false),
                    TotalInterest = table.Column<decimal>(type: "money", nullable: false),
                    TotalPrincipal = table.Column<decimal>(type: "money", nullable: false),
                    TotalTaxes = table.Column<decimal>(type: "money", nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Credit_BankingAccount_BankingAccountID",
                        column: x => x.BankingAccountID,
                        principalTable: "BankingAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UtilityBill",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ammount = table.Column<decimal>(type: "money", nullable: false),
                    BankingAccountID = table.Column<int>(nullable: true),
                    DebtDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Provider = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    SubscriptionNumber = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityBill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UtilityBill_BankingAccount_BankingAccountID",
                        column: x => x.BankingAccountID,
                        principalTable: "BankingAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credit_BankingAccountID",
                table: "Credit",
                column: "BankingAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_UtilityBill_BankingAccountID",
                table: "UtilityBill",
                column: "BankingAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "UtilityBill");
        }
    }
}
