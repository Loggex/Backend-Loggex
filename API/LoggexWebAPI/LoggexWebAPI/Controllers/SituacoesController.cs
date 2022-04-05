using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using Microsoft.AspNetCore.Authorization;

namespace LoggexWebAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SituacoesController : ControllerBase
    {
        private readonly LoggexContext _context;

        public SituacoesController(LoggexContext context)
        {
            _context = context;
        }

        // GET: api/Situacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Situaco>>> GetSituacoes()
        {
            return await _context.Situacoes.ToListAsync();
        }

        // GET: api/Situacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Situaco>> GetSituaco(int id)
        {
            var situaco = await _context.Situacoes.FindAsync(id);

            if (situaco == null)
            {
                return NotFound();
            }

            return situaco;
        }

        // PUT: api/Situacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSituaco(int id, Situaco situaco)
        {
            if (id != situaco.IdSituacao)
            {
                return BadRequest();
            }

            _context.Entry(situaco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SituacoExists(id))
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

        // POST: api/Situacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Situaco>> PostSituaco(Situaco situaco)
        {
            _context.Situacoes.Add(situaco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSituaco", new { id = situaco.IdSituacao }, situaco);
        }

        // DELETE: api/Situacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSituaco(int id)
        {
            var situaco = await _context.Situacoes.FindAsync(id);
            if (situaco == null)
            {
                return NotFound();
            }

            _context.Situacoes.Remove(situaco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SituacoExists(int id)
        {
            return _context.Situacoes.Any(e => e.IdSituacao == id);
        }
    }
}
