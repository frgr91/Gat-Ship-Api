using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GatCrmApi.Models;

namespace GatCrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontaktPersonController : ControllerBase
    {
        private readonly GatshipContext _context;

        public KontaktPersonController(GatshipContext context)
        {
            _context = context;
        }

        /* GET: api/KontaktPerson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KontaktPerson>>> GetKontaktPerson()
        {
            return await _context.KontaktPerson.ToListAsync();
        }
        */

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KontaktPerson>>> GetKontaktPersoner(int? kundenr)
        {
            var kunde = _context.KontaktPerson.AsQueryable();

            if (kundenr != null) // Adds the condition to check availability 
            {
                kunde = _context.KontaktPerson.Where(i => i.KundeNr == kundenr);
            }

            return await kunde.ToListAsync();
        }

        // GET: api/KontaktPerson/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KontaktPerson>> GetKontaktPerson(int id)
        {
            var kontaktPerson = await _context.KontaktPerson.FindAsync(id);

            if (kontaktPerson == null)
            {
                return NotFound();
            }

            return kontaktPerson;
        }

        // PUT: api/KontaktPerson/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKontaktPerson(int id, KontaktPerson kontaktPerson)
        {
            if (id != kontaktPerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(kontaktPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontaktPersonExists(id))
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

        // POST: api/KontaktPerson
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KontaktPerson>> PostKontaktPerson(KontaktPerson kontaktPerson)
        {
            _context.KontaktPerson.Add(kontaktPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKontaktPerson", new { id = kontaktPerson.Id }, kontaktPerson);
        }

        // DELETE: api/KontaktPerson/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KontaktPerson>> DeleteKontaktPerson(int id)
        {
            var kontaktPerson = await _context.KontaktPerson.FindAsync(id);
            if (kontaktPerson == null)
            {
                return NotFound();
            }

            _context.KontaktPerson.Remove(kontaktPerson);
            await _context.SaveChangesAsync();

            return kontaktPerson;
        }

        private bool KontaktPersonExists(int id)
        {
            return _context.KontaktPerson.Any(e => e.Id == id);
        }
    }
}
