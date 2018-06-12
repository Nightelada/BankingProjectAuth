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

        [ForeignKey("BankingAccount")]
        public int? BankingAccountID { get; set; }

        public UtilityBillType Type { get; set; }

        public UtilityBillStatus Status { get; set; }

        public string Name { get; set; }

        [Display(Name = "Subscription Number")]
        public string SubscriptionNumber { get; set; }

        [Display(Name = "Debt Date")]
        public DateTime DebtDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Ammount { get; set; }
        
        public virtual BankingAccount BankingAccount { get; set; }
    }
}
