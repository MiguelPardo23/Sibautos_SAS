using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sibautos_SAS.Models;

namespace Sibautos_SAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasePracticaController : ControllerBase
    {
        private readonly SibautosSasContext _context;

        public ClasePracticaController(SibautosSasContext context)
        {
            _context = context;
        }

        // GET: api/ClasePractica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClasePractica>>> GetClasePracticas()
        {
          if (_context.ClasePracticas == null)
          {
              return NotFound();
          }
            return await _context.ClasePracticas.ToListAsync();
        }

        // GET: api/ClasePractica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClasePractica>> GetClasePractica(int id)
        {
          if (_context.ClasePracticas == null)
          {
              return NotFound();
          }
            var clasePractica = await _context.ClasePracticas.FindAsync(id);

            if (clasePractica == null)
            {
                return NotFound();
            }

            return clasePractica;
        }

        // PUT: api/ClasePractica/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasePractica(int id, ClasePractica clasePractica)
        {
            if (id != clasePractica.IdClaseP)
            {
                return BadRequest();
            }

            _context.Entry(clasePractica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasePracticaExists(id))
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

        // POST: api/ClasePractica
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClasePractica>> PostClasePractica(ClasePractica clasePractica)
        {
          if (_context.ClasePracticas == null)
          {
              return Problem("Entity set 'SibautosSasContext.ClasePracticas'  is null.");
          }
            _context.ClasePracticas.Add(clasePractica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasePractica", new { id = clasePractica.IdClaseP }, clasePractica);
        }

        // DELETE: api/ClasePractica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasePractica(int id)
        {
            if (_context.ClasePracticas == null)
            {
                return NotFound();
            }
            var clasePractica = await _context.ClasePracticas.FindAsync(id);
            if (clasePractica == null)
            {
                return NotFound();
            }

            _context.ClasePracticas.Remove(clasePractica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClasePracticaExists(int id)
        {
            return (_context.ClasePracticas?.Any(e => e.IdClaseP == id)).GetValueOrDefault();
        }
    }
}
