using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingProjectAuth.Models
{

    public enum AccountType
    {
        [Display(Name = "Savings Account")]
        SavingsAccount,
        [Display(Name = "Checking Account")]
        CheckingAccount,
        [Display(Name = "Interest Account")]
        InterestAccount,
        [Display(Name = "Individual Retirement Account")]
        IndividualRetirementAccount,
        [Display(Name = "Offshore Account")]
        OffshoreAccount
    }

    public class BankingAccount
    {
        public int ID { get; set; }

        [ForeignKey("User"), Display(Name = "User ID")]
        public string UserID { get; set; }

        [Display(Name = "Account Type")]
        public AccountType AccountType { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string IBAN { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Column(TypeName = "money")]
        public decimal Available { get; set; }

        [Column(TypeName = "money")]
        public decimal Blocked { get; set; }

        [ForeignKey("Currency"), Display(Name = "Currency ID")]
        public int? CurrencyID { get; set; }

        [Display(Name = "Allowed Overdraft"), Column(TypeName = "money")]
        public decimal AllowedOverdraft { get; set; }

        [Display(Name = "Used Overdraft"), Column(TypeName = "money")]
        public decimal UsedOverdraft { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Currency Currency { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
        public virtual ICollection<Credit> Credits { get; set; }
        public virtual ICollection<UtilityBill> UtilityBills { get; set; }
        public virtual ICollection<MoneyTransfer> MoneyTransfers { get; set; }
    }
}
