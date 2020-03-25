using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            { name = "sanju" };
            // return View();
            // return Content("deepanshu balani is Gr8");
            //return HttpNotFound();
            //return new EmptyResult();
            return RedirectToAction("Index", "Home",new {page=1,sortBy="name"});
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
            return Content(string.Format("pageIndex={1}&sortBy={0}", pageIndex, sortBy));
        }
    }
}