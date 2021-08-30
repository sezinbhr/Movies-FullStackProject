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
    public class GenresController : ControllerBase
    {
        private IGenreService service;

        public GenresController(IGenreService genreService)
        {
            service = genreService;
        }


        [HttpGet]
        [AllowAnonymous]
        
        public IActionResult Get ()
        {
            var result = service.GetAllGenres();
            return Ok(result);

        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var genreListResponse = service.GetGenresById(id);
            if (genreListResponse != null)
            {
                return Ok(genreListResponse);
            }

            return NotFound();

        }

        [HttpGet("GetMoviesByGenre/{genreId}")]
        [AllowAnonymous]

        public IActionResult GetMoviesByGenre(int genreId)
        {
            var result = service.GetMoviesByGenreId(genreId);
            if (result!= null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Editor")]


        public IActionResult AddGenre(AddNewGenreRequest request)
        {

            if (ModelState.IsValid)
            {
                int genreId = service.AddGenre(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = genreId }, value: null);
            }

            return BadRequest(ModelState);
            

        }

        [HttpPut("{id}")]
        [GenreExists]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult UpdateGenre(int id, EditGenreRequest request )
        {

            //var isExisting = service.GetGenresById(id);

            //if (isExisting == null)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateGenre(request);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [GenreExists]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult Delete(int id)
        {

            service.DeleteGenre(id);
            return Ok();
        }
           

    }
}
