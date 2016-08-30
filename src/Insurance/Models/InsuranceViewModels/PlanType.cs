using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Models.InsuranceViewModels
{
    public class PlanType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public InsuranceCompany Company { get; set; }

        public int CompanyId { get; set; }
    }
}
