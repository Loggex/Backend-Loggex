using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;

namespace LoggexWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposPecasController : ControllerBase
    {
        private readonly LoggexContext _context;

        public TiposPecasController(LoggexContext context)
        {
            _context = context;
        }

        // GET: api/TiposPecas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposPeca>>> GetTiposPecas()
        {
            return await _context.TiposPecas.ToListAsync();
        }

        // GET: api/TiposPecas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposPeca>> GetTiposPeca(int id)
        {
            var tiposPeca = await _context.TiposPecas.FindAsync(id);

            if (tiposPeca == null)
            {
                return NotFound();
            }

            return tiposPeca;
        }

        // PUT: api/TiposPecas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposPeca(int id, TiposPeca tiposPeca)
        {
            if (id != tiposPeca.IdTipoPeca)
            {
                return BadRequest();
            }

            _context.Entry(tiposPeca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposPecaExists(id))
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

        // POST: api/TiposPecas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposPeca>> PostTiposPeca(TiposPeca tiposPeca)
        {
            _context.TiposPecas.Add(tiposPeca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposPeca", new { id = tiposPeca.IdTipoPeca }, tiposPeca);
        }

        // DELETE: api/TiposPecas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposPeca(int id)
        {
            var tiposPeca = await _context.TiposPecas.FindAsync(id);
            if (tiposPeca == null)
            {
                return NotFound();
            }

            _context.TiposPecas.Remove(tiposPeca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposPecaExists(int id)
        {
            return _context.TiposPecas.Any(e => e.IdTipoPeca == id);
        }
    }
}
