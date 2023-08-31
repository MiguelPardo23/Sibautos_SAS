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
    public class ContactoAlumosController : ControllerBase
    {
        private readonly SibautosSasContext _context;

        public ContactoAlumosController(SibautosSasContext context)
        {
            _context = context;
        }

        // GET: api/ContactoAlumos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactoAlum>>> GetContactoAlums()
        {
          if (_context.ContactoAlums == null)
          {
              return NotFound();
          }
            return await _context.ContactoAlums.ToListAsync();
        }

        // GET: api/ContactoAlumos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactoAlum>> GetContactoAlum(int id)
        {
          if (_context.ContactoAlums == null)
          {
              return NotFound();
          }
            var contactoAlum = await _context.ContactoAlums.FindAsync(id);

            if (contactoAlum == null)
            {
                return NotFound();
            }

            return contactoAlum;
        }

        // PUT: api/ContactoAlumos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactoAlum(int id, ContactoAlum contactoAlum)
        {
            if (id != contactoAlum.IdContacto)
            {
                return BadRequest();
            }

            _context.Entry(contactoAlum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoAlumExists(id))
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

        // POST: api/ContactoAlumos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactoAlum>> PostContactoAlum(ContactoAlum contactoAlum)
        {
          if (_context.ContactoAlums == null)
          {
              return Problem("Entity set 'SibautosSasContext.ContactoAlums'  is null.");
          }
            _context.ContactoAlums.Add(contactoAlum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactoAlum", new { id = contactoAlum.IdContacto }, contactoAlum);
        }

        // DELETE: api/ContactoAlumos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactoAlum(int id)
        {
            if (_context.ContactoAlums == null)
            {
                return NotFound();
            }
            var contactoAlum = await _context.ContactoAlums.FindAsync(id);
            if (contactoAlum == null)
            {
                return NotFound();
            }

            _context.ContactoAlums.Remove(contactoAlum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactoAlumExists(int id)
        {
            return (_context.ContactoAlums?.Any(e => e.IdContacto == id)).GetValueOrDefault();
        }
    }
}
