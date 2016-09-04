using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Models.InsuranceViewModels
{
    public class Transaction
    {
        public int Id { get; set; }

        public int? ClientId { get; set; }
        public Customer Client { get; set; }

        public int DepositedMoney { get; set; }

        public DateTime TransactionDate { get; set; }

        public int? PlanTypeId { get; set;}
        public PlanType PlanType { get; set; }
    }
}
