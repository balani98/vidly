using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDbContext _context;
        public MoviesController()
        {
            _context = new MovieDbContext();
        }
        //_context is disposable object
        //method to dispose dbContext
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = _context.Movies.Include(c=>c.genre).ToList();
           
           
         
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;
            return View(movies);
           // return Content("deepanshu balani is Gr8");
            //return HttpNotFound();
            //return new EmptyResult();
            // return RedirectToAction("Index", "Home",new {page=1,sortBy="name"});
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        private ViewResult NewMethod()
        {
            return View();
        }

        //PUT:Movies/Edit/:id
        public ActionResult Edit(int id)
        {
            return Content("id="+ id);
        }
        //pagination and sorting(pageIndex and sortBy are optional parameters)
        //:GET:Movies
       
        public ActionResult Index(int?pageIndex,string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";
            return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,15)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }
      


    }
}