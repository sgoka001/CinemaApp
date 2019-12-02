using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinemaApp.Models;

namespace CinemaApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesRWController : ControllerBase
    {
        readonly JobContext _context;

        public MoviesRWController(JobContext context)
        {
            this._context = context;
        }
        // GET: api/MoviesRW
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movies>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        // GET: api/MoviesRW/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MoviesRW
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MoviesRW/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
