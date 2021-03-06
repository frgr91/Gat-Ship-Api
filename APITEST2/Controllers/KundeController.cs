﻿using System;
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
    public class KundeController : ControllerBase
    {
        private readonly GatshipContext _context;

        public KundeController(GatshipContext context)
        {
            _context = context;
        }

        // GET: api/Kunde
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kunde>>> GetKunde()
        {
            return await _context.Kunde.ToListAsync();
        }

        // GET: api/Kunde/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kunde>> GetKunde(int id)
        {
            var kunde = await _context.Kunde.FindAsync(id);

            if (kunde == null)
            {
                return NotFound();
            }

            return kunde;
        }

        // PUT: api/Kunde/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKunde(int id, Kunde kunde)
        {
            if (id != kunde.KundeNr)
            {
                return BadRequest();
            }

            _context.Entry(kunde).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KundeExists(id))
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

        // POST: api/Kunde
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kunde>> PostKunde(Kunde kunde)
        {
            _context.Kunde.Add(kunde);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKunde", new { id = kunde.KundeNr }, kunde);
        }

        // DELETE: api/Kunde/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kunde>> DeleteKunde(int id)
        {
            var kunde = await _context.Kunde.FindAsync(id);
            if (kunde == null)
            {
                return NotFound();
            }

            _context.Kunde.Remove(kunde);
            await _context.SaveChangesAsync();

            return kunde;
        }

        private bool KundeExists(int id)
        {
            return _context.Kunde.Any(e => e.KundeNr == id);
        }
    }
}
