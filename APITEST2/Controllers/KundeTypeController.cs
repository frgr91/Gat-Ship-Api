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
    public class KundeTypeController : ControllerBase
    {
        private readonly GatshipContext _context;

        public KundeTypeController(GatshipContext context)
        {
            _context = context;
        }

        // GET: api/KundeType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KundeType>>> GetKundeType()
        {
            return await _context.KundeType.ToListAsync();
        }

        // GET: api/KundeType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KundeType>> GetKundeType(int id)
        {
            var kundeType = await _context.KundeType.FindAsync(id);

            if (kundeType == null)
            {
                return NotFound();
            }

            return kundeType;
        }

        // PUT: api/KundeType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKundeType(int id, KundeType kundeType)
        {
            if (id != kundeType.Id)
            {
                return BadRequest();
            }

            _context.Entry(kundeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KundeTypeExists(id))
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

        // POST: api/KundeType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KundeType>> PostKundeType(KundeType kundeType)
        {
            _context.KundeType.Add(kundeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKundeType", new { id = kundeType.Id }, kundeType);
        }

        // DELETE: api/KundeType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KundeType>> DeleteKundeType(int id)
        {
            var kundeType = await _context.KundeType.FindAsync(id);
            if (kundeType == null)
            {
                return NotFound();
            }

            _context.KundeType.Remove(kundeType);
            await _context.SaveChangesAsync();

            return kundeType;
        }

        private bool KundeTypeExists(int id)
        {
            return _context.KundeType.Any(e => e.Id == id);
        }
    }
}
