using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Insurance.Models.InsuranceViewModels;
using Insurance.Data;

namespace Insurance.Controllers
{
    public class InsuranceController : Controller
    {

        ApplicationDbContext context;

        public InsuranceController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer c)
        {
            this.context.Add(c);
            this.context.SaveChanges();

            return View("", "");
        }

        public IActionResult ShowCustomers()
        {
            return View(this.context.Customers.ToList());
        }
    }
}