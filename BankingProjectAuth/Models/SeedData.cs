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

        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                var accounts = new List<Account> {
                        new Account
                        {
                            AccountType = AccountType.CheckingAccount,
                            IBAN = "123123123123",
                            Balance = 3500.00M,
                            Available = 400.20M,
                            Blocked = 5600.10M,
                            Currency = "BGN",
                            AllowedOverdraft = 300.00M,
                            UsedOverdraft = 150.00M
                        },
                         new Account
                         {
                             AccountType = AccountType.InterestAccount,
                             IBAN = "444444444444",
                             Balance = -400.00M,
                             Available = 123.20M,
                             Blocked = 52600.10M,
                             Currency = "BGN",
                             AllowedOverdraft = 300.00M,
                             UsedOverdraft = 0.00001M
                         },
                          new Account
                          {
                              AccountType = AccountType.SavingsAccount,
                              IBAN = "BG123HJDI@7631H",
                              Balance = 3300.030M,
                              Available = 400.20M,
                              Blocked = 5610.10M,
                              Currency = "BGN",
                              AllowedOverdraft = 800.00M,
                              UsedOverdraft = 150.00M
                          },
                           new Account
                           {
                               AccountType = AccountType.IndividualRetirementAccount,
                               IBAN = "BG12323232323",
                               Balance = 330.030M,
                               Available = 40.20M,
                               Blocked = -50.10M,
                               Currency = "EUR",
                               AllowedOverdraft = 8000.00M,
                               UsedOverdraft = 1500.00M
                           }
                        };
                // Look for any accounts.
                if (!context.Account.Any())
                {
                    context.Account.AddRange(accounts);
                    context.SaveChanges();
                }
                else
                {
                    accounts = context.Account.ToList();
                }


                var cards = new List<Card> {
                    new Card
                    {
                        AccountID = accounts[0].ID,
                        Type = CardType.Credit,
                        Provider = CardProvider.MasterCard,
                        CardHolder = "Pepkata",
                        DailyLimit = 400.20M,
                        MontlyLimit = 5600.10M,
                        POSLimit = 2299.88M,
                        Status = CardStatus.Suspended
                    },
                    new Card
                    {
                        AccountID = accounts[1].ID,
                        Type = CardType.Debit,
                        Provider = CardProvider.VISA,
                        CardHolder = "Vankata",
                        DailyLimit = 333,
                        MontlyLimit = 444,
                        POSLimit = 555,
                        Status = CardStatus.Pending
                    },
                    new Card
                    {
                        AccountID = accounts[2].ID,
                        Type = CardType.ATM,
                        Provider = CardProvider.Discover,
                        CardHolder = "Tonkata",
                        DailyLimit = 4123.23330M,
                        MontlyLimit = 41124124.4321M,
                        POSLimit = 2124451.123M,
                        Status = CardStatus.Activated
                    },
                    new Card
                    {
                        AccountID = accounts[3].ID,
                        Type = CardType.Virtual,
                        Provider = CardProvider.AmericanExpress,
                        CardHolder = "Ickata",
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

                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        FirstName = "Petar",
                        LastName = "Hristov",
                        Gender = Gender.Male,
                        Address = "Sofia, Druzhba 2, bl.409, vh.V, et.8, ap.72",
                        DateOfBirth = DateTime.Now,
                        PhoneNumber = "0878787878",
                        AccountID = accounts[0].ID,
                        Email = "pepi3000@abv.bg",
                        NormalizedEmail = "PEPI3000@ABV.BG",
                        EmailConfirmed = true,
                        UserName = "pepi3000@abv.bg",
                        NormalizedUserName = "PEPI3000@ABV.BG"
                    }
                };

                if (!context.User.Any())
                {
                    userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    foreach (ApplicationUser user in users)
                    {
                        IdentityResult asd = await userManager.CreateAsync(user, "Dardar123");
                    }
                }
            }
        }
    }
}