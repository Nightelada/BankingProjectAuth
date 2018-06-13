using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingProjectAuth.Models
{
    public enum CardType
    {
        Debit,
        Credit,
        ATM,
        Virtual
    }

    public enum CardProvider
    {
        VISA,
        [Display(Name = "Master Card")]
        MasterCard,
        [Display(Name = "American Express")]
        AmericanExpress,
        Discover
    }

    public enum CardStatus
    {
        Activated,
        Suspended,
        Pending
    }

    public class Card
    {
        public int ID { get; set; }

        [ForeignKey("BankingAccount")]
        public int? BankingAccountID { get; set; }

        public CardType Type { get; set; }

        public CardProvider Provider { get; set; }

        [Display(Name = "Cardholder"), StringLength(100, MinimumLength = 3)]
        public string CardHolder { get; set; }

        [Display(Name = "Daily Limit"), Column(TypeName = "money")]
        public decimal DailyLimit { get; set; }

        [Display(Name = "Monthly Limit"), Column(TypeName = "money")]
        public decimal MontlyLimit { get; set; }

        [Display(Name = "POS Limit"), Column(TypeName = "money")]
        public decimal POSLimit { get; set; }

        public CardStatus Status { get; set; }

        [Display(Name = "Banking Account")]
        public virtual BankingAccount BankingAccount { get; set; }
    }
}
