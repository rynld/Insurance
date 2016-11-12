using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime;
using Microsoft.AspNetCore.Mvc;
using Insurance.Models.InsuranceViewModels;
using Insurance.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Insurance.Data.Auxiliar;
using System.IO;
using CsvHelper;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

using Insurance.Controllers.Insurance.Data.Auxiliar;
using Microsoft.Net.Http.Headers;

namespace Insurance.Controllers
{
    public class InsuranceController : Controller
    {
        ApplicationDbContext context;
        IHostingEnvironment _appEnvironment;

        public InsuranceController(ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {

            this.context = context;
            this._appEnvironment = appEnvironment;
            //context.Database.OpenConnection();
            //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Customers ON");
            //this.context.Customers.Add(new Customer() {
            //    Name = "pepe"
            //});
            //this.context.Database.CloseConnection();
            //this.context.SaveChanges();
            //AddInitialData();
        }

        public void AddInitialData()
        {


            //this.context.InsuranceCompanies.Add(new InsuranceCompany() {
            //    Name = "Medicare",
            //    PlanTypes = new List<PlanType>() {
            //        new PlanType() {
            //            Name="FullMed"},
            //        new PlanType() {
            //            Name="MediumMed"},
            //        new PlanType() {
            //            Name="PartialMed"}
            //    }
            //});
            //this.context.InsuranceCompanies.Add(new InsuranceCompany()
            //{
            //    Name = "BBQ",
            //    PlanTypes = new List<PlanType>() {
            //        new PlanType() {
            //            Name="SpecialBBQ"},
            //        new PlanType() {
            //            Name="OldBBQ"}
            //    }
            //});


            var r = new Random();
            var list = this.context.PlanTypes.ToList();

            for (int i = 0; i < 20; i++)
            {
                this.context.Transactions.Add(new Transaction()
                {
                    DepositedMoney = r.Next(30),
                    ClientId = r.Next(3, 8),
                    PlanType = list[r.Next(list.Count)],
                    TransactionDate = new DateTime(2016, r.Next(1, 13), r.Next(1, 28))

                });
            }
            this.context.SaveChanges();
        }

        public IActionResult AddCustomer()
        {

            List<SelectListItem> res = new List<SelectListItem>();

            foreach (var item in this.context.InsuranceCompanies)
                res.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });

            this.ViewBag.InsuranceNames = res;
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerViewModel c)
        {
            var new_customer = new Customer()
            {
                Name = c.FirstName,
                LastName = c.LastName,
                MiddleName = c.MiddleName,
                FullName = Regex.Replace(c.FirstName + " " + c.MiddleName + " " + c.LastName, @"\s+", " "),
                Email = c.Email,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                SocialSecurity = c.SocialSecurity,
                State = c.State,
                StateOfBirth = c.StateOfBirth,
                ZipCode = c.ZipCode,
                DateOfBirth = c.DateOfBirth
            };
            this.context.Customers.Add(new_customer);
            this.context.SaveChanges();

            //Add new sale
            var plan = this.context.PlanTypes.First(p => p.Name == c.PlanType);

            var newsale = new Sale()
            {
                Customer = this.context.Customers.Single(cus => cus == new_customer),
                DirectAgent = c.DirectAgent,
                ReferringAgent = c.ReferringAgent,
                LeadAgent = c.LeadAgent,
                ProductName = plan,
                Carrier = this.context.InsuranceCompanies.First(i => i.Id == plan.CompanyId),
                EffectiveDate = c.EffectiveDate,
                TerminationDate = c.TerminationDate

            };
            this.context.Sales.Add(newsale);
            this.context.SaveChanges();
            return RedirectToAction("ShowCustomers");
        }

        public IActionResult ShowCustomers()
        {

            return View(this.context.Customers.ToList());
        }

        public JsonResult InsuranceTypes(string insuranceid)
        {
            var plans = this.context.PlanTypes.Where(x => x.Company.Id == int.Parse(insuranceid));

            List<SelectListItem> res = new List<SelectListItem>();
            foreach (var item in plans)
                res.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });

            return new JsonResult(res);
        }

        public IActionResult Transaction()
        {
            var trans = this.context.Transactions.Include(t => t.Client).Include(t => t.PlanType).ToList();

            return View(trans);
        }

        public IActionResult PaymentHistory()
        {
            
            return View(this.context.Payments.Include(p=>p.Customer).ToList());
        }

        public IActionResult Sales()
        {
            return View(this.context.Sales.Include(p => p.Customer).Include(p => p.ProductName)
                .Include(p => p.Carrier).ToList());
        }

        public IActionResult Transactions()
        {
            return View(new PaymentData[] { });
        }

        public IActionResult GetInfoPayments(int user_id)
        {
            var result = this.context.Payments.Where(p => p.Customer.Id == user_id);
            ViewBag.total = result.Sum(p => p.AmountPaid);
            return View(result);
            
        }

        [HttpPost]
        public IActionResult AddPaymentsFromFile(IFormFile file)
        {
            string file_path = Path.Combine(this._appEnvironment.ContentRootPath, "ExternalFiles");
            string name_file = DateTime.Now.Ticks.ToString() + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string file_name = Path.Combine(file_path, name_file);

            using (FileStream fs = System.IO.File.Create(file_name))
            {
                file.CopyTo(fs);
                fs.Flush();
            }


            List<PaymentData> allValues;

            List<bool> indatabase = new List<bool>();
            using (TextReader fileReader = System.IO.File.OpenText(file_name))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.IgnoreHeaderWhiteSpace = true;

                allValues = csv.GetRecords<PaymentData>().ToList();
                var customers = this.context.Customers.Select(c => c.FullName)
                    .Distinct().ToDictionary(c => c);

                
                foreach (var item in allValues)
                {
                    indatabase.Add(customers.ContainsKey(item.CustomerName));
                    if (indatabase[indatabase.Count - 1])
                    {
                        DateTime date;
                        var can = DateTime.TryParse(item.StatementDate, out date);

                        try
                        {
                            var payment = new SalePayment()
                            {
                                Customer = this.context.Customers.Where(c => c.FullName == item.CustomerName).First(),
                                AmountPaid = GetAmount(item.AmountPaid),
                                DatePayment = (can)?date:DateTime.MinValue
                            };
                            this.context.Payments.Add(payment);
                        }
                        catch (Exception e)
                        {
                            indatabase[indatabase.Count - 1] = false;
                        }

                        //if (this.context.Payments.FirstOrDefault() == null)
                        //    this.context.Payments.Add(payment);
                    }
                }
            }

            this.context.SaveChanges();

            ViewBag.data = true;
            ViewBag.allValues = allValues;
            ViewBag.indatabase = indatabase;
            return View("PaymentHistory");
            //return this.Json(new object[] { allValues, indatabase });
        }

        [HttpPost]
        public IActionResult AddSalesFromFile(IFormFile file)
        {
            List<SaleData> allValues;

            string path_file = this._appEnvironment.ContentRootPath + "\\ExternalFiles\\" + file.FileName + DateTime.Now.ToString();
            using (FileStream fs = System.IO.File.Create(path_file))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            List<bool> indatabase = new List<bool>();
            double aux;
            using (TextReader fileReader = System.IO.File.OpenText(path_file))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.IgnoreHeaderWhiteSpace = true;
                csv.Configuration.WillThrowOnMissingField = false;
                allValues = csv.GetRecords<SaleData>().ToList();
                var customers = this.context.Customers.Select(c => c.FullName)
                    .Distinct().ToDictionary(c => c);

                //context.Database.OpenConnection();
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Sales OFF");

                foreach (var item in allValues)
                {
                    if (customers.ContainsKey(item.Customer))
                    {
                        var plan = this.context.PlanTypes.FirstOrDefault(p => p.Name == item.ProductName);
                        //Avmed
                        this.context.Sales.Add(new Sale()
                        {
                            Customer = this.context.Customers.First(c => c.FullName == item.Customer),
                            DirectAgent = item.DirectAgt,
                            ReferringAgent = item.ReferringAgt,
                            LeadAgent = item.LeadAgt,
                            ProductName = plan,
                            Carrier = this.context.InsuranceCompanies.FirstOrDefault(c => c.Name == item.Carrier),
                            Metal = item.Metal,
                            MemberQuantity = int.Parse(item.MbrCT),
                            EffectiveDate = (item.EffectiveDate != "") ? DateTime.Parse(item.EffectiveDate) : new DateTime(1000, 1, 1),
                            TerminationDate = (item.TerminationDate != "") ? DateTime.Parse(item.TerminationDate) : new DateTime(3333, 1, 1),
                            Premium = ((item.Carrier == "AvMed") ? ((double.TryParse(item.Premium.Substring(1), out aux)) ? double.Parse(item.Premium.Substring(1)) : double.NaN) : double.NaN)

                        });
                        //this.context.Sales.Add(new Sale()
                        //{
                        //    Customer = this.context.Customers.First(c => c.FullName == item.Customer),
                        //    DirectAgent = item.DirectAgt,
                        //    ReferringAgent = item.ReferringAgt,
                        //    LeadAgent = item.LeadAgt,
                        //    ProductName = plan,
                        //    Carrier = this.context.InsuranceCompanies.FirstOrDefault(c => c.Name == item.Carrier),
                        //    Metal = item.Metal,
                        //    MemberQuantity = int.Parse(item.MbrCT),
                        //    EffectiveDate = (item.EffectiveDate != "") ? DateTime.Parse(item.EffectiveDate) : new DateTime(1000, 1, 1),
                        //    TerminationDate = (item.TerminationDate != "") ? DateTime.Parse(item.TerminationDate) : new DateTime(3333, 1, 1),


                        //});
                    }
                    else
                    {
                        throw new Exception("tremendo problema");
                    }
                }

                this.context.SaveChanges();
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Sales OFF");
                //context.SaveChanges();
                //context.Database.CloseConnection();
            }
            return new JsonResult("");

        }


        public IActionResult GenerateReport(DateTime date)
        {
            date = new DateTime(2016, 6, 25);
            var t = this.context.Payments.Where(p => p.DatePayment == date).ToList();
            var x = (from sales in this.context.Sales.Include(s => s.Customer)
                     join pay in this.context.Payments on sales.ID equals pay.Customer.Id
                     where pay.DatePayment == date
                     select new { sales.Customer.FullName, pay.AmountPaid });
            return View();
        }

        public double GetAmount(string text)
        {
            double val;
            if (text[0] == '(')
            {
                return -1*double.Parse(text.Substring(2, text.Length - 3));
                val *= -1;
            }
            return double.Parse(text.Substring(1));
        }

    }
}