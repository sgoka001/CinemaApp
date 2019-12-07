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
    [Route("api/[controller]")]
    [ApiController]
    public class GenreMovieVMController : ControllerBase
    {
        private readonly JobContext _context;

        public GenreMovieVMController(JobContext context)
        {
            _context = context;
        }

        // GET: api/GenreMovieVM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreMovieVM>>> GetGenreMovieVM()
        {
            return await _context.GenreMovieVM.ToListAsync();
        }

        // GET: api/GenreMovieVM/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreMovieVM>> GetGenreMovieVM(string id)
        {
            var genreMovieVM = await _context.GenreMovieVM.FindAsync(id);

            if (genreMovieVM == null)
            {
                return NotFound();
            }

            return genreMovieVM;
        }

        // PUT: api/GenreMovieVM/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenreMovieVM(string id, GenreMovieVM genreMovieVM)
        {
            if (id != genreMovieVM.genreVM)
            {
                return BadRequest();
            }

            _context.Entry(genreMovieVM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreMovieVMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GenreMovieVM
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GenreMovieVM>> PostGenreMovieVM(GenreMovieVM genreMovieVM)
        {
            _context.GenreMovieVM.Add(genreMovieVM);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GenreMovieVMExists(genreMovieVM.genreVM))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGenreMovieVM", new { id = genreMovieVM.genreVM }, genreMovieVM);
        }

        // DELETE: api/GenreMovieVM/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenreMovieVM>> DeleteGenreMovieVM(string id)
        {
            var genreMovieVM = await _context.GenreMovieVM.FindAsync(id);
            if (genreMovieVM == null)
            {
                return NotFound();
            }

            _context.GenreMovieVM.Remove(genreMovieVM);
            await _context.SaveChangesAsync();

            return genreMovieVM;
        }

        private bool GenreMovieVMExists(string id)
        {
            return _context.GenreMovieVM.Any(e => e.genreVM == id);
        }
    }
}
