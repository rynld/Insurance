using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Models.InsuranceViewModels
{
    public class Sale
    {
        public int ID { get; set; }

        public Customer Customer { get; set; }

        public string DirectAgent { get; set; }

        public string ReferringAgent { get; set; }

        public string LeadAgent { get; set; }

        public PlanType ProductName { get; set; }

        public InsuranceCompany Carrier { get; set; }

        public string Metal { get; set; }

        public int MemberQuantity { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime TerminationDate { get; set; }

        public double Premium { get; set; }
    }
}
