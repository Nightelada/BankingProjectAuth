﻿using BankingProjectAuth.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BankingProjectAuth.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any accounts.
                if (!context.Account.Any())
                {
                    context.Account.AddRange(
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
                    );
                    context.SaveChanges();
                }
                // Look for any customers.
                if (!context.Customer.Any())
                {
                    context.Customer.AddRange(
                         new Customer
                         {
                             AccountId = 1,
                             Address = "Blagoevgrad",
                             DateOfBirth = DateTime.Parse("1989-1-11"),
                             Email = "blagoevgrad@abv.bg",
                             FirstName = "Blago",
                             LastName = "Evgrad",
                             Gender = "Female",
                             Phone = "0-800",
                             Username = "pepkata1",
                             Password = "test",
                             ConfirmPassword = "test"
                         },

                        new Customer
                        {
                            AccountId = 2,
                            Address = "Sofia",
                            DateOfBirth = DateTime.Parse("1989-1-11 12:00:00"),
                            Email = "sofia@abv.bg",
                            FirstName = "So",
                            LastName = "Fia",
                            Gender = "Male",
                            Phone = "0-800",
                            Username = "pepkata2",
                            Password = "test",
                            ConfirmPassword = "test"
                        },

                        new Customer
                        {
                            AccountId = 3,
                            Address = "Selishte",
                            DateOfBirth = DateTime.Parse("1989-1-11"),
                            Email = "selishte@abv.bg",
                            FirstName = "Seli",
                            LastName = "Shte",
                            Gender = "Apache Helicopter",
                            Phone = "0-500",
                            Username = "pepkata3",
                            Password = "test",
                            ConfirmPassword = "test"
                        },

                       new Customer
                       {
                           AccountId = 4,
                           Address = "Finland",
                           DateOfBirth = DateTime.Parse("1989-1-11"),
                           Email = "finland@abv.bg",
                           FirstName = "Fin",
                           LastName = "Land",
                           Gender = "Other",
                           Phone = "0-600",
                           Username = "pepkata4",
                           Password = "test",
                           ConfirmPassword = "test"
                       }
                    );
                    context.SaveChanges();
                }
                // Look for any cards.
                if (!context.Card.Any())
                {
                    context.Card.AddRange(
                        new Card
                        {
                            AccountID = 4,
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
                            AccountID = 2,
                            Type = CardType.Debit,
                            Provider = CardProvider.VISA,
                            CardHolder = "Vankata",
                            DailyLimit = 333,
                            MontlyLimit = 444,
                            POSLimit = 555,
                            Status = CardStatus.Pending
                        }, new Card
                        {
                            AccountID = 3,
                            Type = CardType.ATM,
                            Provider = CardProvider.Discover,
                            CardHolder = "Tonkata",
                            DailyLimit = 4123.23330M,
                            MontlyLimit = 41124124.4321M,
                            POSLimit = 2124451.123M,
                            Status = CardStatus.Activated
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}