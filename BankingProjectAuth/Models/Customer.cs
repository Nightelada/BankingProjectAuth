using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingProjectAuth.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Display(Name = "First Name"), StringLength(100, MinimumLength = 3)]
        [ForeignKey("Account")]
        public int? AccountId { get; set; }
        public string FirstName { get; set; }
        [Display(Name = "Last Name"), StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress), StringLength(255)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Date of Birth"), DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [StringLength(30, MinimumLength = 3)]
        public string Username { get; set; }
        [StringLength(30, MinimumLength = 3)]
        public string Password { get; set; }
        [NotMapped]
        [StringLength(30, MinimumLength = 3), DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords dont match.")]
        public string ConfirmPassword { get; set; }

        public virtual Account Account { get; set; }
    }
}
