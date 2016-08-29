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
        }

        public IActionResult AddCustomer()
        {
            this.ViewBag.InsuranceNames = new SelectListItem[] {
                new SelectListItem() { Value="pp",Text="Pepe"},
                new SelectListItem() { Value="pd",Text="Pedro"},
                new SelectListItem() { Value="jl",Text="Julio"},
            };
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
            return new JsonResult(new { name="susano",lastname="rcky"});
        }

    }
}