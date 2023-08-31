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
    public class ClaseTeoricaController : ControllerBase
    {
        private readonly SibautosSasContext _context;

        public ClaseTeoricaController(SibautosSasContext context)
        {
            _context = context;
        }

        // GET: api/ClaseTeorica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaseTeorica>>> GetClaseTeoricas()
        {
          if (_context.ClaseTeoricas == null)
          {
              return NotFound();
          }
            return await _context.ClaseTeoricas.ToListAsync();
        }

        // GET: api/ClaseTeorica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClaseTeorica>> GetClaseTeorica(int id)
        {
          if (_context.ClaseTeoricas == null)
          {
              return NotFound();
          }
            var claseTeorica = await _context.ClaseTeoricas.FindAsync(id);

            if (claseTeorica == null)
            {
                return NotFound();
            }

            return claseTeorica;
        }

        // PUT: api/ClaseTeorica/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaseTeorica(int id, ClaseTeorica claseTeorica)
        {
            if (id != claseTeorica.IdClaseT)
            {
                return BadRequest();
            }

            _context.Entry(claseTeorica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaseTeoricaExists(id))
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

        // POST: api/ClaseTeorica
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClaseTeorica>> PostClaseTeorica(ClaseTeorica claseTeorica)
        {
          if (_context.ClaseTeoricas == null)
          {
              return Problem("Entity set 'SibautosSasContext.ClaseTeoricas'  is null.");
          }
            _context.ClaseTeoricas.Add(claseTeorica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaseTeorica", new { id = claseTeorica.IdClaseT }, claseTeorica);
        }

        // DELETE: api/ClaseTeorica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaseTeorica(int id)
        {
            if (_context.ClaseTeoricas == null)
            {
                return NotFound();
            }
            var claseTeorica = await _context.ClaseTeoricas.FindAsync(id);
            if (claseTeorica == null)
            {
                return NotFound();
            }

            _context.ClaseTeoricas.Remove(claseTeorica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClaseTeoricaExists(int id)
        {
            return (_context.ClaseTeoricas?.Any(e => e.IdClaseT == id)).GetValueOrDefault();
        }
    }
}
