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
    [Route("api/kundekundetype")]
    [ApiController]
    public class Kunde_KundeTypController : ControllerBase
    {
        private readonly GatshipContext _context;

        public Kunde_KundeTypController(GatshipContext context)
        {
            _context = context;
        }

        // GET: api/Kunde_KundeTyp
        /*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kunde_KundeType>>> GetKunde_KundeType()
        {
            return await _context.Kunde_KundeType.ToListAsync();
        }
        */

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kunde_KundeType>>> GetKunde_KundeType(int? kundenr) { 
            var kunde = _context.Kunde_KundeType.AsQueryable();

            if (kundenr != null) // Adds the condition to check availability 
            {
                kunde = _context.Kunde_KundeType.Where(i => i.KundeNr == kundenr);
            }

            return await kunde.ToListAsync();
        }

        // GET: api/Kunde_KundeTyp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kunde_KundeType>> GetKunde_KundeType(int id)
        {
            var kunde_KundeType = await _context.Kunde_KundeType.FindAsync(id);

            if (kunde_KundeType == null)
            {
                return NotFound();
            }

            return kunde_KundeType;
        }

        // PUT: api/Kunde_KundeTyp/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKunde_KundeType(int id, Kunde_KundeType kunde_KundeType)
        {
            if (id != kunde_KundeType.Id)
            {
                return BadRequest();
            }

            _context.Entry(kunde_KundeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Kunde_KundeTypeExists(id))
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

        // POST: api/Kunde_KundeTyp
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kunde_KundeType>> PostKunde_KundeType(Kunde_KundeType kunde_KundeType)
        {
            _context.Kunde_KundeType.Add(kunde_KundeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKunde_KundeType", new { id = kunde_KundeType.Id }, kunde_KundeType);
        }

        // DELETE: api/Kunde_KundeTyp/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kunde_KundeType>> DeleteKunde_KundeType(int id)
        {
            var kunde_KundeType = await _context.Kunde_KundeType.FindAsync(id);
            if (kunde_KundeType == null)
            {
                return NotFound();
            }

            _context.Kunde_KundeType.Remove(kunde_KundeType);
            await _context.SaveChangesAsync();

            return kunde_KundeType;
        }

        private bool Kunde_KundeTypeExists(int id)
        {
            return _context.Kunde_KundeType.Any(e => e.Id == id);
        }
    }
}
