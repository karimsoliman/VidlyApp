using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customersVm = getCustomers();
            return View(customersVm);
        }

        public ActionResult Details(int id)
        {
            var customers = getCustomers();
            var specifiedCustomer = customers.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(specifiedCustomer);
        }

        private CustomersVm getCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer(){ Id = 1,Name = "Mohamed"},
                new Customer() {Id = 2, Name = "Ali" }
            };

            CustomersVm customersVm = new CustomersVm()
            {
                Customers = customers
            };
            return customersVm;
        }
    }
}