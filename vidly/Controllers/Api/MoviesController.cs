using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Models;

namespace vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private MovieDbContext _context;
        public MoviesController()
        {
            _context =new MovieDbContext();

        }
        //GET:/api/movies
        public IHttpActionResult getMovies()
        {
            var movies = _context.Movies.ToList();
            if (movies == null)
                return NotFound();
            return Ok(movies);
        }
        //GET:/api/movies/1
        public IHttpActionResult getMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.id == id);
            if (movie == null)
                return NotFound();
            return Ok(movie);

        }
        //POST:/api/movies
        [HttpPost]
        public IHttpActionResult createMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.id),movie);
         }

        [HttpPut]
        public IHttpActionResult updateMovie(Movie movie,int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Request");
            
            var movieinDb = _context.Movies.SingleOrDefault(c => c.id == id);
            if (movieinDb == null)
                return NotFound();
            movieinDb.name = movie.name;
            movieinDb.dateAdded = DateTime.Now;
            movieinDb.genre_Id = movie.genre_Id;
            movieinDb.releaseDate = movie.releaseDate;
            _context.SaveChanges();
            return Ok(movie);
        }
        public IHttpActionResult deleteMovie(int id)
        {
            var movieinDb = _context.Movies.SingleOrDefault(c => c.id == id);
            if (movieinDb == null)
                return NotFound();
            _context.Movies.Remove(movieinDb);
            _context.SaveChanges();
            return Ok( "movie deleted");
        }
    }
}
