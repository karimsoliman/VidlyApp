using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public VidlyDBContext _context;

        public CustomersController()
        {
            _context = new VidlyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            //var customersVm = new CustomersVm() { Customers = customers};
            return View();
        }

        public ActionResult Details(int id)
        {
            var specifiedCustomer = _context.Customers.Include(c => c.MemberShipType).FirstOrDefault(c => c.Id == id);
            return View(specifiedCustomer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var membershipTypes = _context.MemebershipTypes.ToList();
            var viewModel = new CustomerFormVm() { Customer = customer, MembershipTypes = membershipTypes };
            return View("CustomerForm", viewModel); 
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MemebershipTypes.ToList();
            var addCustomerVm = new CustomerFormVm() { MembershipTypes = membershipTypes};
            return View("CustomerForm", addCustomerVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            ModelState.Remove("customer.Id");
            if (!ModelState.IsValid)
            {
                var membershipTypes = _context.MemebershipTypes.ToList();
                var viewModel = new CustomerFormVm() { Customer = customer, MembershipTypes = membershipTypes};
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}