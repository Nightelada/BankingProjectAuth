using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingProjectAuth.Models
{

    public enum CreditType
    {
        [Display(Name = "Real Estate")]
        RealEstate,
        [Display(Name = "Financial Institution")]
        FinancialInstitution,
        Agricultural,
        Commercial,
        Industrial,
        Individual,
        Other
    }

    public enum CreditDuration
    {
        [Display(Name = "Short-Term")]
        ShortTerm,
        [Display(Name = "Mid-Term")]
        MidTerm,
        [Display(Name = "Long-Term")]
        LongTerm
    }

    public class Credit
    {
        public int ID { get; set; }

        [ForeignKey("BankingAccount"), Display(Name = "Banking Account ID")]
        public int? BankingAccountID { get; set; }

        public CreditType Type { get; set; }

        public CreditDuration Duration { get; set; }

        [Display(Name = "Total Principal"), Column(TypeName = "money")]
        public decimal TotalPrincipal { get; set; }

        [Display(Name = "Owed Principal"), Column(TypeName = "money")]
        public decimal OwedPrincipal { get; set; }

        [Display(Name = "Overdue Principal"), Column(TypeName = "money")]
        public decimal OverduePrincipal { get; set; }

        [Display(Name = "Interest Rate")]
        public decimal InterestRate { get; set; }

        [Display(Name = "Total Interest"), Column(TypeName = "money")]
        public decimal TotalInterest { get; set; }

        [Display(Name = "Owed Interest"), Column(TypeName = "money")]
        public decimal OwedInterest { get; set; }

        [Display(Name = "Overdue Interest"), Column(TypeName = "money")]
        public decimal OverdueInterest { get; set; }

        [Display(Name = "Installment Amount"), Column(TypeName = "money")]
        public decimal InstallmentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Next Installment")]
        public DateTime NextInstallment { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Installment")]
        public DateTime LastInstallment { get; set; }

        [Display(Name = "Total Taxes"), Column(TypeName = "money")]
        public decimal TotalTaxes { get; set; }

        [Display(Name = "Owed Taxes"), Column(TypeName = "money")]
        public decimal OwedTaxes { get; set; }

        [Display(Name = "Overdue Taxes"), Column(TypeName = "money")]
        public decimal OverdueTaxes { get; set; }

        [Display(Name = "Banking Account")]
        public virtual BankingAccount BankingAccount { get; set; }
    }
}
