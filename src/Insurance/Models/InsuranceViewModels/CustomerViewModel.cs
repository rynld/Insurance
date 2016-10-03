using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Models.InsuranceViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }


        public string SocialSecurity { get; set; }


        public string StateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string AnnualIncome { get; set; }

        public string PlanType { get; set; }

        //Properties of sales

        public string DirectAgent { get; set; }

        public string ReferringAgent { get; set; }

        [DisplayName("Lead Agent")]
        public string LeadAgent { get; set; }


        public DateTime EffectiveDate { get; set; }

        public DateTime TerminationDate { get; set; }


    }
}
