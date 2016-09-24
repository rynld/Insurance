using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Models.InsuranceViewModels
{
    public class SalePayment
    {
        public int SalePaymentId { get; set; }

        public Customer Customer { get; set; }

        public DateTime DatePayment { get; set; }

        public double AmountPaid { get; set; }

        public InsuranceCompany InsuranceCompany { get; set;}
    }
}
