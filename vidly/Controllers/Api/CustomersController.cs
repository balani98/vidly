using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Models;

namespace vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private MovieDbContext _context;
        public CustomersController()
        {
            _context = new MovieDbContext();

        }
        //GET /api/customers
        public IEnumerable<Customer> getCustomers()
        {
            return _context.Customers.ToList();
        }
        //GET /api/customers/1
        public Customer getcustomer(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;

        }
        //POST api/customers
        [HttpPost]
        public Customer createCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;

        }
        //PUT api/customers/1
        [HttpPut]
        public void updateCustomer(int id,Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerinDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerinDb.name = customer.name;
            customerinDb.dateOfBirth = customer.dateOfBirth;
            customerinDb.membershipTypeId = customer.membershipTypeId;
            customerinDb.isSubsribedToNewsletter = customer.isSubsribedToNewsletter;
            customerinDb.membershipTypeId = customer.membershipTypeId;

            _context.SaveChanges();
        }
        //DELETE api/customers/1
        [HttpDelete]
        public void deleteCustomer(int id)
        {
            var customerinDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerinDb);
            _context.SaveChanges();
        }
        
    }
}
