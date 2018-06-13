using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingProjectAuth.Models
{
    public enum TransferType
    {
        [Display(Name = "Automatic Check Handling")]
        ACH,
        [Display(Name = "Domestic Wire Transfer")]
        Domestic,
        [Display(Name = "International Wire Transfer")]
        International,
        [Display(Name = "Commercial Wire Transfer")]
        Commercial,
        [Display(Name = "Transfer Between Own Accounts")]
        BetweenOwnAccounts,
        [Display(Name = "Direct Debit")]
        DirectDebit
    }
    public class MoneyTransfer
    {
        public int ID { get; set; }

        [ForeignKey("BankingAccount")]
        public int? BankingAccountID { get; set; }

        public TransferType Type { get; set; }

        public string Currency { get; set; }

        [Display(Name = "Recipient Name"), StringLength(255, MinimumLength = 3)]
        public string RecipientName { get; set; }

        [Display(Name = "Recipient IBAN"), StringLength(30, MinimumLength = 3)]
        public string RecipientIBAN { get; set; }

        [Display(Name = "Recipient Country"), StringLength(50, MinimumLength = 3)]
        public string RecipientCountry { get; set; }

        [Display(Name = "Recipient Address"), StringLength(255, MinimumLength = 3)]
        public string RecipientAddress { get; set; }

        [StringLength(50)]
        public string Reason { get; set; }

        [Display(Name = "Additional Reason"), StringLength(500)]
        public string AdditionalReason { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "Date of Transfer")]
        public DateTime TransferDate { get; set; }

        [Display(Name = "Banking Account")]
        public virtual BankingAccount BankingAccount { get; set; }

    }
}
