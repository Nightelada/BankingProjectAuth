﻿// <auto-generated />
using BankingProjectAuth.Data;
using BankingProjectAuth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BankingProjectAuth.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180613190853_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankingProjectAuth.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.BankingAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountType");

                    b.Property<decimal>("AllowedOverdraft")
                        .HasColumnType("money");

                    b.Property<decimal>("Available")
                        .HasColumnType("money");

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<decimal>("Blocked")
                        .HasColumnType("money");

                    b.Property<int?>("CurrencyID");

                    b.Property<string>("IBAN")
                        .HasMaxLength(30);

                    b.Property<decimal>("UsedOverdraft")
                        .HasColumnType("money");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("CurrencyID");

                    b.HasIndex("UserID");

                    b.ToTable("BankingAccount");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.Card", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BankingAccountID");

                    b.Property<string>("CardHolder")
                        .HasMaxLength(100);

                    b.Property<decimal>("DailyLimit")
                        .HasColumnType("money");

                    b.Property<decimal>("MontlyLimit")
                        .HasColumnType("money");

                    b.Property<decimal>("POSLimit")
                        .HasColumnType("money");

                    b.Property<int>("Provider");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("BankingAccountID");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.Credit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BankingAccountID");

                    b.Property<int>("Duration");

                    b.Property<decimal>("InstallmentAmmount")
                        .HasColumnType("money");

                    b.Property<decimal>("InterestRate");

                    b.Property<DateTime>("LastInstallment");

                    b.Property<DateTime>("NextInstallment");

                    b.Property<decimal>("OverdueInterest")
                        .HasColumnType("money");

                    b.Property<decimal>("OverduePrincipal")
                        .HasColumnType("money");

                    b.Property<decimal>("OverdueTaxes")
                        .HasColumnType("money");

                    b.Property<decimal>("OwedInterest")
                        .HasColumnType("money");

                    b.Property<decimal>("OwedPrincipal")
                        .HasColumnType("money");

                    b.Property<decimal>("OwedTaxes")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalInterest")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalPrincipal")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalTaxes")
                        .HasColumnType("money");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("BankingAccountID");

                    b.ToTable("Credit");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.Currency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .HasMaxLength(20);

                    b.Property<string>("Country")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.MoneyTransfer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalReason")
                        .HasMaxLength(500);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int?>("BankingAccountID");

                    b.Property<string>("Currency");

                    b.Property<string>("Reason")
                        .HasMaxLength(50);

                    b.Property<string>("RecipientAddress")
                        .HasMaxLength(255);

                    b.Property<string>("RecipientCountry")
                        .HasMaxLength(50);

                    b.Property<string>("RecipientIBAN")
                        .HasMaxLength(30);

                    b.Property<string>("RecipientName")
                        .HasMaxLength(255);

                    b.Property<DateTime>("TransferDate");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("BankingAccountID");

                    b.ToTable("MoneyTransfer");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.UtilityBill", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int?>("BankingAccountID");

                    b.Property<DateTime>("DebtDate");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<string>("SubscriptionNumber")
                        .HasMaxLength(50);

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("BankingAccountID");

                    b.ToTable("UtilityBill");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.BankingAccount", b =>
                {
                    b.HasOne("BankingProjectAuth.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyID");

                    b.HasOne("BankingProjectAuth.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.Card", b =>
                {
                    b.HasOne("BankingProjectAuth.Models.BankingAccount", "BankingAccount")
                        .WithMany("Cards")
                        .HasForeignKey("BankingAccountID");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.Credit", b =>
                {
                    b.HasOne("BankingProjectAuth.Models.BankingAccount", "BankingAccount")
                        .WithMany("Credits")
                        .HasForeignKey("BankingAccountID");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.MoneyTransfer", b =>
                {
                    b.HasOne("BankingProjectAuth.Models.BankingAccount", "BankingAccount")
                        .WithMany("MoneyTransfers")
                        .HasForeignKey("BankingAccountID");
                });

            modelBuilder.Entity("BankingProjectAuth.Models.UtilityBill", b =>
                {
                    b.HasOne("BankingProjectAuth.Models.BankingAccount", "BankingAccount")
                        .WithMany("UtilityBills")
                        .HasForeignKey("BankingAccountID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BankingProjectAuth.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BankingProjectAuth.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankingProjectAuth.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BankingProjectAuth.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
