using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Models.InsuranceViewModels
{
    public class PlanType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual InsuranceCompany Company { get; set; }

        public int CompanyId { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
