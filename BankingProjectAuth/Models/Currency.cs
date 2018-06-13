using System.ComponentModel.DataAnnotations;

namespace BankingProjectAuth.Models
{
    public class Currency
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        public virtual string CurrencyInfo => $"{Code} - {Name} | {Country}";
    }
}
