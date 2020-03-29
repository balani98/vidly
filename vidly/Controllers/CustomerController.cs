using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using System.Data.Entity;
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
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult formView()
        {
            return View();

        }
   }
}