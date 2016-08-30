﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Models.InsuranceViewModels
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public InsuranceCompany InsuranceName { get; set; }

        public PlanType PlanType { get; set; }
    }
}