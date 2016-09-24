using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ManageData
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using (var db = new DbApplication())
            {
                Console.WriteLine("21312");
            }

            return;
            string path = "C:\\Users\\Reynaldo\\Desktop\\playin\\CustomerT.csv";



            using (TextReader fileReader = System.IO.File.OpenText(path))
            {
                var csv = new CsvReader(fileReader);
                var allValues = csv.GetRecords<Customer>().ToList();
                

                foreach (var item in allValues)
                {
                    //indatabase.Add(customers.ContainsKey(item.CustomerName));
                }
            }
        }
    }

    public class Customer
    {
        public int Id { get; set; }

      
        public string Name { get; set; }

     
        public string LastName { get; set; }

        public string MiddleName { get; set; }

      
        public string Email { get; set; }

  
        
        public DateTime DateOfBirth { get; set; }

     
        public string PhoneNumber { get; set; }

        public string SocialSecurity { get; set; }

        public string StateOfBirth { get; set; }

     
        public string Address { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public double AnnualIncome { get; set; }

    }

    public class DbApplication : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Application;Trusted_Connection=True;");
            
        }
    }
}
