using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Models.InsuranceViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepositedMoney { get; set; }

        public DateTime TransactionDate { get; set; }

        public string PlanType { get; set; }
    }
}
