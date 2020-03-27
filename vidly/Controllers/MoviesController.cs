using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = GetMovies();
           
           
         
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;
            return View(movies);
           // return Content("deepanshu balani is Gr8");
            //return HttpNotFound();
            //return new EmptyResult();
            // return RedirectToAction("Index", "Home",new {page=1,sortBy="name"});
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
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { id = 1, name = "Delhi-6" },
                new Movie { id = 2, name = "Sanju" }
            };
        }


    }
}