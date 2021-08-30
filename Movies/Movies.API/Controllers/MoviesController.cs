using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Filters;
using Movies.Business;
using Movies.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        private IMovieService service;

        public MoviesController(IMovieService movieService)
        {
            service = movieService;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var result = service.GetAllMovies();
            return Ok(result);

        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var movieListResponse = service.GetMoviesById(id);
            if (movieListResponse != null)
            {
                return Ok(movieListResponse);
            }

            return NotFound();

        }

        [HttpGet("Search/{title}")]
        [AllowAnonymous]

        public IActionResult SearchMovie([FromQuery(Name = "title")] string title)
        {
            var result = service.SearchMovie(title);
            if (result!=null)
            {
                return Ok(result);
            }

            return NotFound();
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Editor")]

        public IActionResult AddMovie(AddNewMovieRequest request)
        {

            if (ModelState.IsValid)
            {
                int movieId = service.AddMovie(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = movieId }, value: null);
            }

            return BadRequest(ModelState);


        }

        [HttpPut("{id}")]
        [MovieExists]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult UpdateMovie(int id, EditMovieRequest request)
        {

            
            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateMovie(request);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [MovieExists]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult Delete(int id)
        {

            service.DeleteMovie(id);
            return Ok();
        }

    }
}
