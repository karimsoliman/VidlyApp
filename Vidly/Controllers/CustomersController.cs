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
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            var customersVm = new CustomersVm() { Customers = customers};
            return View(customersVm);
        }

        public ActionResult Details(int id)
        {
            var specifiedCustomer = _context.Customers.Include(c => c.MemberShipType).FirstOrDefault(c => c.Id == id);
            return View(specifiedCustomer);
        }

        public ActionResult New()
        {
            return View();
        }
    }
}