using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankingProjectAuth.Data.Migrations
{
    public partial class remove_customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 30, nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Username = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customer_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AccountId",
                table: "Customer",
                column: "AccountId");
        }
    }
}
