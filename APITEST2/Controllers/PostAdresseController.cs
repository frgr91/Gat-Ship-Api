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
    public class PostAdresseController : ControllerBase
    {
        private readonly GatshipContext _context;

        public PostAdresseController(GatshipContext context)
        {
            _context = context;
        }

        // GET: api/PostAdresse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostAdresse>>> GetPostAdresse()
        {
            return await _context.PostAdresse.ToListAsync();
        }

        // GET: api/PostAdresse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostAdresse>> GetPostAdresse(int id)
        {
            var postAdresse = await _context.PostAdresse.FindAsync(id);

            if (postAdresse == null)
            {
                return NotFound();
            }

            return postAdresse;
        }

        // PUT: api/PostAdresse/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostAdresse(int id, PostAdresse postAdresse)
        {
            if (id != postAdresse.PostNr)
            {
                return BadRequest();
            }

            _context.Entry(postAdresse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostAdresseExists(id))
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

        // POST: api/PostAdresse
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PostAdresse>> PostPostAdresse(PostAdresse postAdresse)
        {
            _context.PostAdresse.Add(postAdresse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostAdresse", new { id = postAdresse.PostNr }, postAdresse);
        }

        // DELETE: api/PostAdresse/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostAdresse>> DeletePostAdresse(int id)
        {
            var postAdresse = await _context.PostAdresse.FindAsync(id);
            if (postAdresse == null)
            {
                return NotFound();
            }

            _context.PostAdresse.Remove(postAdresse);
            await _context.SaveChangesAsync();

            return postAdresse;
        }

        private bool PostAdresseExists(int id)
        {
            return _context.PostAdresse.Any(e => e.PostNr == id);
        }
    }
}
