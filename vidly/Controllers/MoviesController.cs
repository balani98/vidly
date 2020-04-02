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
            var movies = _context.Movies.Include(c => c.genre).ToList();
            return View(movies);
          
        }
        public ActionResult formMovieView()
        {
            var genres = _context.genres.ToList();
            var viewModels = new NewMovieViewModel
            { Movie =new Movie(),
                Genres = genres
            };
            return View("formMovieView", viewModels);
        }
        [HttpPost]
        public ActionResult save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    Genres = _context.genres.ToList()
                };
                return View("formMovieView",viewModel);
            }

            if (movie.id != 0)
            {

                var movieInDb = _context.Movies.Single(c => c.id == movie.id);
                movieInDb.name = movie.name;
                movieInDb.releaseDate = movie.releaseDate;
                movieInDb.dateAdded = movie.dateAdded;
                movieInDb.genre_Id = movie.genre_Id;
                
               }
            else
            {

                _context.Movies.Add(movie);
            }
            _context.SaveChanges();
            return RedirectToAction("Random", "Movies");
        }
        public ActionResult edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres=_context.genres
              
            };
            return View("formMovieView", viewModel);
        }

    }
}