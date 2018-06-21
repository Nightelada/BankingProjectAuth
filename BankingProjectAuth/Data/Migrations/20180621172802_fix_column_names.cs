using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankingProjectAuth.Data.Migrations
{
    public partial class fix_column_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InstallmentAmmount",
                table: "Credit",
                newName: "InstallmentAmount");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Card",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InstallmentAmount",
                table: "Credit",
                newName: "InstallmentAmmount");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Card",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 16,
                oldNullable: true);
        }
    }
}
