using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BankingProjectAuth.Models
{
    public enum Gender
    {
        Male,
        Female,
        [Display(Name = "Apache Helicopter")]
        ApacheHelicopter,
        Other
    }

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name"), StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name"), StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Date of Birth"), DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("Account")]
        public int? AccountID { get; set; }
        public virtual Account Account { get; set; }
    }
}
