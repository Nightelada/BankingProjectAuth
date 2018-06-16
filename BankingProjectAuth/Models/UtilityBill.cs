using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingProjectAuth.Models
{
    public enum UtilityBillType
    {
        Charity,
        [Display(Name = "Water Supply")]
        WaterSupply,
        [Display(Name = "Gas Companies")]
        GasCompanies,
        Electricity,
        Telecommunications,
        Insurance,
        Internet,
        TV,
        Education,
        [Display(Name = "House Manager")]
        HouseManager,
        [Display(Name = "Security Equipment")]
        SecurityEquipment,
        [Display(Name = "Thermal Energy")]
        ThermalEnergy,
        [Display(Name = "Loan Repayment")]
        LoanRepayment,
        Other
    }
    
    public enum UtilityBillStatus
    {
        Paid,
        Pending,
        Overdue
    }

    public class UtilityBill
    {
        public int ID { get; set; }

        [ForeignKey("BankingAccount"), Display(Name = "Banking Account ID")]
        public int? BankingAccountID { get; set; }

        public UtilityBillType Type { get; set; }

        public UtilityBillStatus Status { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Subscription Number"), StringLength(50)]
        public string SubscriptionNumber { get; set; }

        [Display(Name = "Debt Date")]
        public DateTime DebtDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Display(Name = "Banking Account")]
        public virtual BankingAccount BankingAccount { get; set; }
    }
}
