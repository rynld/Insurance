using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Data.Auxiliar
{
    public class SaleData
    {
        public string SaleID { get; set; }

        public string Customer { get; set; }

        public string DirectAgt { get; set; }

        public string ReferringAgt { get; set; }

        public string LeadAgt { get; set; }

        public string ProductName { get; set; }

        public string Carrier { get; set; }

        public string Metal { get; set; }

        public string MbrCT { get; set; }


        public string EffectiveDate { get; set; }

        public string TerminationDate { get; set; }

        public string Premium { get; set; }
    }
}
