using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingProjectAuth.Models.BankingAccountViewModels
{
    public class TestViewModel
    {
        public IEnumerable<BankingAccount> Accounts { get; set; }
        public IEnumerable<Card> Cards { get; set; }
        public BankingAccount SingeAccount { get; set; }
        public Card SingleCard { get; set; }

    }
}
