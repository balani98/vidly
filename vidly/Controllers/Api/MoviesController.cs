using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using vidly.Dto;
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
            Mapper.Initialize(cfg => cfg.CreateMap<Movie, MovieDto>());
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        
            if (movies == null)
                return NotFound();
            return Ok(movies);
        }
        //GET:/api/movies/1
        public IHttpActionResult getMovie(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Movie, MovieDto>());
            var movie = _context.Movies.SingleOrDefault(c => c.id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie,MovieDto>(movie));

        }
        //POST:/api/movies
        [HttpPost]
        public IHttpActionResult createMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Mapper.Initialize(cfg => cfg.CreateMap<MovieDto, Movie>());
            var movie = Mapper.Map<MovieDto,Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.id),movie);
         }

        [HttpPut]
        public IHttpActionResult updateMovie(MovieDto movieDto,int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Request");
            
           
           
            var movieinDb = _context.Movies.SingleOrDefault(c => c.id == id);
            if (movieinDb == null)
                return NotFound();
            //movieDto.id = id;
            Mapper.Initialize(cfg => cfg.CreateMap<MovieDto, Movie>().ForMember(m => m.id, opt => opt.Ignore()));
            Mapper.Map(movieDto, movieinDb);
           
            _context.SaveChanges();
            return Ok("Movie updated");
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
