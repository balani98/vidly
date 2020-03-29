using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using System.Data.Entity;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomerController : Controller
    {
        private MovieDbContext _context;
        public CustomerController()
        {
            _context = new MovieDbContext();
        }
        //_context is disposable object
        //method to dispose dbContext
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer/display
       
            
        public ActionResult display()
        {
            var customers = _context.Customers.Include(c=>c.membershipType).ToList();
            return View(customers);
        }
        public ActionResult formView()
        {
            var membershipTypes = _context.membershipTypes.ToList();
            var viewModels = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("formView",viewModels);


        }
        public ActionResult edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.membershipTypes
            };
            return View("formView",viewModel);
        }
        [HttpPost]
        public ActionResult create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("display", "Customer");
        }    

        
       
   }
}