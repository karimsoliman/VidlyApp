using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Vidly.Models;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private VidlyDBContext _context;

        public CustomersController()
        {
            _context = new VidlyDBContext();
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult Customers()
        {
            var result = _context.Customers.Include(c => c.MemberShipType).Select(Mapper.Map<Customer, CustomerDTO>).ToList();
            return Ok(result);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetCustomerById(int id)
        {
            var result = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(result));
        }

        [HttpPost]
        public IHttpActionResult AddCustomer(CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerTobeAdded = Mapper.Map<CustomerDTO, Customer>(customer);
            _context.Customers.Add(customerTobeAdded);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customerTobeAdded.Id), customerTobeAdded);
        }

        [HttpPut]
        public IHttpActionResult EditCustomer(CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);

            if (customerInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(customer, customerInDb);
            _context.SaveChanges();

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
