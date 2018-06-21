using BankingProjectAuth.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingProjectAuth.Models
{
    public class SeedData
    {
        private static UserManager<ApplicationUser> userManager;
        private static RoleManager<IdentityRole> roleManager;
        private const string adminRole = "Administrator";
        private const string adminName = "Administrator";

        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                ApplicationUser adminUser = new ApplicationUser
                {
                    FirstName = "Petar",
                    LastName = "Hristov",
                    Gender = Gender.Male,
                    Address = "Sofia, Druzhba 2, bl.409, vh.V, et.8, ap.72",
                    DateOfBirth = DateTime.Now,
                    PhoneNumber = "0878787878",
                    Email = "pepi3000@abv.bg",
                    NormalizedEmail = "PEPI3000@ABV.BG",
                    EmailConfirmed = true,
                    UserName = "pepi3000@abv.bg",
                    NormalizedUserName = "PEPI3000@ABV.BG"
                };

                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        FirstName = "Ivan",
                        LastName = "Vankata",
                        Gender = Gender.Other,
                        Address = "Sofia, ne bash druzhba",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "234234234234",
                        Email = "nightelada@abv.bg",
                        NormalizedEmail = "NIGHTELADA@ABV.BG",
                        EmailConfirmed = true,
                        UserName = "nightelada@abv.bg",
                        NormalizedUserName = "NIGHTELADA@ABV.BG"
                    },
                    new ApplicationUser
                    {
                        FirstName = "Toni",
                        LastName = "Tonkata",
                        Gender = Gender.ApacheHelicopter,
                        Address = "Sofia, ne bash studentski",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "6565327345",
                        Email = "nightelada@gmail.com",
                        NormalizedEmail = "NIGHTELADA@GMAIL.COM",
                        EmailConfirmed = true,
                        UserName = "nightelada@gmail.com",
                        NormalizedUserName = "NIGHTELADA@GMAIL.COM"
                    },
                     new ApplicationUser
                    {
                        FirstName = "Icako",
                        LastName = "Ickata",
                        Gender = Gender.Female,
                        Address = "Sofia, ne bash seminariqta",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "2222222222",
                        Email = "random@aaaa.bbb",
                        NormalizedEmail = "RANDOM@AAAA.BBB",
                        EmailConfirmed = true,
                        UserName = "random@aaaa.bbb",
                        NormalizedUserName = "RANDOM@AAAA.BBB"
                    }
                };

                if (!context.Role.Any())
                {
                    bool checkAdminRoleExists = await roleManager.RoleExistsAsync(adminRole);
                    if (!checkAdminRoleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(adminRole));
                    }
                }

                if (!context.User.Any(x => x.Email.Equals(adminUser.Email)))
                {
                    await userManager.CreateAsync(adminUser, "Dardar123");
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }

                if (context.User.Count() == 1)
                {
                    foreach (ApplicationUser user in users)
                    {
                        await userManager.CreateAsync(user, "Dardar123");
                    }
                }

                users = context.User.ToList();
                var currencies = context.Currency.ToList();

                var accounts = new List<BankingAccount> {
                        new BankingAccount
                        {
                            AccountType = AccountType.CheckingAccount,
                            IBAN = "123123123123",
                            Balance = 3500.00M,
                            Available = 400.20M,
                            Blocked = 5600.10M,
                            Currency = currencies.Find(x => x.Country.Equals("Bulgaria")),
                            AllowedOverdraft = 300.00M,
                            UsedOverdraft = 150.00M,
                            User = users[0]
                        },
                         new BankingAccount
                         {
                             AccountType = AccountType.InterestAccount,
                             IBAN = "444444444444",
                             Balance = -400.00M,
                             Available = 123.20M,
                             Blocked = 52600.10M,
                             Currency = currencies.Find(x => x.Country.Equals("Cyprus")),
                             AllowedOverdraft = 300.00M,
                             UsedOverdraft = 0.00001M,
                             User = users[1]
                         },
                          new BankingAccount
                          {
                              AccountType = AccountType.SavingsAccount,
                              IBAN = "BG123HJDI@7631H",
                              Balance = 3300.030M,
                              Available = 400.20M,
                              Blocked = 5610.10M,
                              Currency = currencies.Find(x => x.Country.Equals("United States of America")),
                              AllowedOverdraft = 800.00M,
                              UsedOverdraft = 150.00M,
                              User = users[2]
                          },
                           new BankingAccount
                           {
                               AccountType = AccountType.IndividualRetirementAccount,
                               IBAN = "BG12323232323",
                               Balance = 330.030M,
                               Available = 40.20M,
                               Blocked = -50.10M,
                               Currency = currencies.Find(x => x.Country.Equals("Morocco")),
                               AllowedOverdraft = 8000.00M,
                               UsedOverdraft = 1500.00M,
                               User = users[3]
                           }
                        };
                // Look for any accounts.
                if (!context.BankingAccount.Any())
                {
                    context.BankingAccount.AddRange(accounts);
                    context.SaveChanges();
                }
                else
                {
                    accounts = context.BankingAccount.ToList();
                }

                var cards = new List<Card> {
                    new Card
                    {
                        BankingAccount = accounts[2],
                        Type = CardType.Credit,
                        Provider = CardProvider.MasterCard,
                        Number = "1234123412341234",
                        CardHolder = "PETAR PETROV",
                        DailyLimit = 400.20M,
                        MontlyLimit = 5600.10M,
                        POSLimit = 2299.88M,
                        Status = CardStatus.Suspended
                    },
                    new Card
                    {
                        BankingAccount = accounts[2],
                        Type = CardType.Debit,
                        Provider = CardProvider.VISA,
                        Number = "4321432143214321",
                        CardHolder = "IVAN IVANON",
                        DailyLimit = 333,
                        MontlyLimit = 444,
                        POSLimit = 555,
                        Status = CardStatus.Pending
                    },
                    new Card
                    {
                        BankingAccount = accounts[1],
                        Type = CardType.ATM,
                        Provider = CardProvider.Discover,
                        Number = "5678567856785678",
                        CardHolder = "ANTON ANTONOV",
                        DailyLimit = 4123.23330M,
                        MontlyLimit = 41124124.4321M,
                        POSLimit = 2124451.123M,
                        Status = CardStatus.Activated
                    },
                    new Card
                    {
                        BankingAccount = accounts[2],
                        Type = CardType.Virtual,
                        Provider = CardProvider.AmericanExpress,
                        Number = "9876987698769876",
                        CardHolder = "HRISTO HRISTOV",
                        DailyLimit = 4113.23330M,
                        MontlyLimit = 156,
                        POSLimit = 222,
                        Status = CardStatus.Activated
                    }
                };

                // Look for any cards.
                if (!context.Card.Any())
                {
                    context.Card.AddRange(cards);
                    context.SaveChanges();
                }

                var credits = new List<Credit>
                {
                    new Credit()
                    {
                        Type = CreditType.Individual,
                        Duration = CreditDuration.ShortTerm,
                        TotalPrincipal = 4000,
                        OwedPrincipal = 2000,
                        OverduePrincipal = 0,
                        InterestRate = 5.5M,
                        TotalInterest = 1200,
                        OwedInterest = 600,
                        OverdueInterest = 20,
                        InstallmentAmount = 222.44M,
                        NextInstallment = DateTime.Now,
                        LastInstallment = DateTime.Now.AddMonths(2),
                        TotalTaxes = 230,
                        OwedTaxes = 115,
                        OverdueTaxes = 1,
                        BankingAccount = accounts[0]
                    },
                    new Credit()
                    {
                        Type = CreditType.Individual,
                        Duration = CreditDuration.LongTerm,
                        TotalPrincipal = 1233,
                        OwedPrincipal = 445,
                        OverduePrincipal = 0,
                        InterestRate = 17.89M,
                        TotalInterest = 111,
                        OwedInterest = 22,
                        OverdueInterest = 5,
                        InstallmentAmount = 254.5M,
                        NextInstallment = DateTime.Now,
                        LastInstallment = DateTime.Now.AddMonths(2),
                        TotalTaxes = 444,
                        OwedTaxes = 111,
                        OverdueTaxes = 1,
                        BankingAccount = accounts[1]
                    },
                    new Credit()
                    {
                        Type = CreditType.Industrial,
                        Duration = CreditDuration.MidTerm,
                        TotalPrincipal = 7245,
                        OwedPrincipal = 6234,
                        OverduePrincipal = 11,
                        InterestRate = 5.35M,
                        TotalInterest = 95,
                        OwedInterest = 9,
                        OverdueInterest = 0,
                        InstallmentAmount = 99.98M,
                        NextInstallment = DateTime.Now,
                        LastInstallment = DateTime.Now.AddMonths(2),
                        TotalTaxes = 5,
                        OwedTaxes = 1,
                        OverdueTaxes = 1,
                        BankingAccount = accounts[2]
                    },
                    new Credit()
                    {
                        Type = CreditType.Agricultural,
                        Duration = CreditDuration.LongTerm,
                        TotalPrincipal = 18000,
                        OwedPrincipal = 12000,
                        OverduePrincipal = 1500,
                        InterestRate = 3.47M,
                        TotalInterest = 3200,
                        OwedInterest = 1800,
                        OverdueInterest = 0,
                        InstallmentAmount = 555.67M,
                        NextInstallment = DateTime.Now,
                        LastInstallment = DateTime.Now.AddMonths(2),
                        TotalTaxes = 123,
                        OwedTaxes = 12,
                        OverdueTaxes = 12,
                        BankingAccount = accounts[3]
                    },
                    new Credit()
                    {
                        Type = CreditType.Agricultural,
                        Duration = CreditDuration.LongTerm,
                        TotalPrincipal = 18000,
                        OwedPrincipal = 12000,
                        OverduePrincipal = 1500,
                        InterestRate = 3.47M,
                        TotalInterest = 3200,
                        OwedInterest = 1800,
                        OverdueInterest = 0,
                        InstallmentAmount = 555.67M,
                        NextInstallment = DateTime.Now,
                        LastInstallment = DateTime.Now.AddMonths(2),
                        TotalTaxes = 123,
                        OwedTaxes = 12,
                        OverdueTaxes = 12,
                        BankingAccount = accounts[2]
                    }
                };

                // Look for any credits
                if (!context.Credit.Any())
                {
                    context.Credit.AddRange(credits);
                    context.SaveChanges();
                }

                var utilityBills = new List<UtilityBill>
                {
                    new UtilityBill()
                    {
                        Type = UtilityBillType.Telecommunications,
                        Status = UtilityBillStatus.Pending,
                        Name = "VIVACOM Monthly Recurring Charges",
                        SubscriptionNumber = "1010101010",
                        DebtDate = DateTime.Now,
                        Amount = 26.26M,
                        BankingAccount = accounts[2]
                    },
                    new UtilityBill()
                    {
                        Type = UtilityBillType.WaterSupply,
                        Status = UtilityBillStatus.Paid,
                        Name = "Sofia water",
                        SubscriptionNumber = "121212",
                        DebtDate = DateTime.Now,
                        Amount = 2611.26M,
                        BankingAccount = accounts[2]
                    },
                    new UtilityBill()
                    {
                        Type = UtilityBillType.Education,
                        Status = UtilityBillStatus.Pending,
                        Name = "TU-Sofia semestrial tax",
                        SubscriptionNumber = "56777765",
                        DebtDate = DateTime.Now,
                        Amount = 26.2226M,
                        BankingAccount = accounts[2]
                    },
                    new UtilityBill()
                    {
                        Type = UtilityBillType.HouseManager,
                        Status = UtilityBillStatus.Overdue,
                        Name = "House Keeper Factory",
                        SubscriptionNumber = "4445",
                        DebtDate = DateTime.Now,
                        Amount = 333,
                        BankingAccount = accounts[2]
                    }
                };

                // Look for any credits
                if (!context.UtilityBill.Any())
                {
                    context.UtilityBill.AddRange(utilityBills);
                    context.SaveChanges();
                }

                var moneyTransfers = new List<MoneyTransfer>()
                {
                    new MoneyTransfer()
                    {
                        BankingAccount = accounts[2],
                        Type = TransferType.Domestic,
                        Currency = currencies.Find(x => x.Country.Equals("Bulgaria")),
                        RecipientName = "PETYO PETYOV",
                        RecipientIBAN = "BG1245612331",
                        RecipientCountry = "Bulgaria",
                        RecipientAddress = "Sofia",
                        Reason = "SMS services",
                        AdditionalReason = "",
                        TransferDate = DateTime.Now,
                        Amount = 0.15M
                    },
                    new MoneyTransfer()
                    {
                        BankingAccount = accounts[2],
                        Type = TransferType.International,
                        Currency = currencies.Find(x => x.Country.Equals("United Kingdom")),
                        RecipientName = "MERRY POPPINS",
                        RecipientIBAN = "UK123523482",
                        RecipientCountry = "United Kingdom",
                        RecipientAddress = "London",
                        Reason = "Goods payment",
                        AdditionalReason = "Stereo headphones",
                        TransferDate = DateTime.Now,
                        Amount = 55.66M
                    },
                    new MoneyTransfer()
                    {
                        BankingAccount = accounts[2],
                        Type = TransferType.ACH,
                        Currency = currencies.Find(x => x.Country.Equals("Singapore")),
                        RecipientName = "TYWIN",
                        RecipientIBAN = "TY123485413",
                        RecipientCountry = "N/A",
                        RecipientAddress = "N/A",
                        Reason = "Check book issued",
                        AdditionalReason = "",
                        TransferDate = DateTime.Now,
                        Amount = 140
                    },
                    new MoneyTransfer()
                    {
                        BankingAccount = accounts[2],
                        Type = TransferType.BetweenOwnAccounts,
                        Currency = currencies.Find(x => x.Country.Equals("Bulgaria")),
                        RecipientName = "PETYO PETYOV",
                        RecipientIBAN = "BG1245612331",
                        RecipientCountry = "Bulgaria",
                        RecipientAddress = "Sofia",
                        Reason = "Credit card payment",
                        AdditionalReason = "",
                        TransferDate = DateTime.Now,
                        Amount = 1000.01M
                    }
                };

                // Look for any money transfers
                if (!context.MoneyTransfer.Any())
                {
                    context.MoneyTransfer.AddRange(moneyTransfers);
                    context.SaveChanges();
                }
            }
        }
    }
}