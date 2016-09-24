using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Models.InsuranceViewModels
{
    public class Customer
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual PlanType PlanType { get; set; }

        public IEnumerable<SalePayment> SalePayments { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string SocialSecurity { get; set; }

        public string StateOfBirth { get; set; }     

        [Required]
        public string Address { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        //public double AnnualIncome { get; set; }

    }
}
