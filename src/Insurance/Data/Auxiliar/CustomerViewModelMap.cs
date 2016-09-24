
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Insurance.Models.InsuranceViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Data.Auxiliar
{
    public class CustomerViewModelMap:CsvClassMap<CustomerViewModel>
    {
        public CustomerViewModelMap()
        {
            Map(c=>c.CustomerId).Name("CustomerID");
            Map(c => c.FirstName).Name("First");
            Map(c => c.LastName).Name("Last");
            Map(c => c.MiddleName).Name("Middle");
            Map(c => c.DateOfBirth).Name("DOB");
            Map(c => c.SocialSecurity).Name("SS");
            Map(c => c.StateOfBirth).Name("State of Birth");
            Map(c => c.Email).Name("Email");
            Map(c => c.PhoneNumber).Name("Phone Number");
            Map(c => c.Address).Name("Address");
            Map(c => c.State).Name("State");
            Map(c => c.ZipCode).Name("Zip");
            Map(c => c.AnnualIncome).Name("Annual Income");
            Map(c => c.PlanType).Ignore();



        }
    }

    public class AnnualIncomeConverter : DefaultTypeConverter
    {

        public override object ConvertFromString(TypeConverterOptions options, string text)
        {
            return ((string)text).Substring(1);
        }
        public override string ConvertToString(TypeConverterOptions options, object value)
        {
            return ((string)value).Substring(1);
        }
    }
}
