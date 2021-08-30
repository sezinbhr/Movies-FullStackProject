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
    public class DirectorsController : ControllerBase
    {
        private IDirectorService service;

        public DirectorsController(IDirectorService directorService)
        {
            service = directorService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var result = service.GetAllDirectors();
            return Ok(result);

        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var directorListResponse = service.GetDirectorsById(id);
            if (directorListResponse != null)
            {
                return Ok(directorListResponse);
            }

            return NotFound();

        }


        [HttpGet("MoviesDirector/{directorId}")]
        [AllowAnonymous]

        public IActionResult GetMoviesDirector(int directorId)
        {
            var result = service.GetMoviesByDirectorId(directorId);
            if (result!=null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("search/{dirName}")]
        [AllowAnonymous]

        public IActionResult SearchDirector([FromQuery(Name = "name")] string dirName)
        {
            var result = service.SearchDirector(dirName);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult AddDirector(AddNewDirectorRequest request)
        {

            if (ModelState.IsValid)
            {
                int directorId = service.AddDirector(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = directorId }, value: null);
            }

            return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        [DirectorExists]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult UpdateDirector(int id, EditDirectorRequest request)
        {

            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateDirector(request);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [DirectorExists]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult Delete(int id)
        {

            service.DeleteDirector(id);
            return Ok();
        }

    }
}
