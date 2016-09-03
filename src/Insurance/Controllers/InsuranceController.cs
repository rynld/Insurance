using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Insurance.Models.InsuranceViewModels;
using Insurance.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Insurance.Controllers
{
    public class InsuranceController : Controller
    {

        ApplicationDbContext context;

        public InsuranceController(ApplicationDbContext context)
        {
            this.context = context;
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
                this.context.Transactions.Add(new Transaction() {
                    DepositedMoney = r.Next(30),
                    Name = "john doe"+r.Next(4).ToString(),
                    PlanType = list[r.Next(list.Count)].Name,
                    TransactionDate = new DateTime(2016,r.Next(1,13),r.Next(1,28))
                 
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
        public IActionResult AddCustomer(Customer c)
        {
            this.context.Add(c);
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

            return View(this.context.Transactions.ToList());
        }


    }
}