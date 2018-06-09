using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingProjectAuth.Models
{
    public class CustomerGenderView
    {
        public List<Customer> customers;
        public SelectList genders;
        public string customerGender { get; set; }
    }
}
