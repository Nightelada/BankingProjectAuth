using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingProjectAuth.Models.BankingAccountViewModels
{
    public class TestViewModel
    {
        public BankingAccount bAccount { get; set; }
        public IEnumerable<Card> Cards { get; set; }
    }
}
