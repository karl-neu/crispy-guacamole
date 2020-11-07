using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/Engines")]
    [ApiController]
    public class EnginesController : ControllerBase
    {
        private readonly carsDatabaseContext _context;

        public EnginesController(carsDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Engines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Engine>>> GetEngine()
        {
            return await _context.Engine.ToListAsync();
        }

        // GET: api/Engines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Engine>> GetEngine(int id)
        {
            var engine = await _context.Engine.FindAsync(id);

            if (engine == null)
            {
                return NotFound();
            }

            return engine;
        }

        // PUT: api/Engines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEngine(int id, Engine engine)
        {
            if (id != engine.Id)
            {
                return BadRequest();
            }

            _context.Entry(engine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineExists(id))
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

        // POST: api/Engines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Engine>> PostEngine(Engine engine)
        {
            _context.Engine.Add(engine);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEngine), new { id = engine.Id }, engine);
        }

        // DELETE: api/Engines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Engine>> DeleteEngine(int id)
        {
            var engine = await _context.Engine.FindAsync(id);
            if (engine == null)
            {
                return NotFound();
            }

            _context.Engine.Remove(engine);
            await _context.SaveChangesAsync();

            return engine;
        }

        private bool EngineExists(int id)
        {
            return _context.Engine.Any(e => e.Id == id);
        }
    }
}
