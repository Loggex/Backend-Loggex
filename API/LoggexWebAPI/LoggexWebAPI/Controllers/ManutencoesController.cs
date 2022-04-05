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
    public class ManutencoesController : ControllerBase
    {
        private readonly LoggexContext _context;

        public ManutencoesController(LoggexContext context)
        {
            _context = context;
        }

        // GET: api/Manutencoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manutenco>>> GetManutencoes()
        {
            return await _context.Manutencoes.ToListAsync();
        }

        // GET: api/Manutencoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manutenco>> GetManutenco(int id)
        {
            var manutenco = await _context.Manutencoes.FindAsync(id);

            if (manutenco == null)
            {
                return NotFound();
            }

            return manutenco;
        }

        // PUT: api/Manutencoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManutenco(int id, Manutenco manutenco)
        {
            if (id != manutenco.IdManutencao)
            {
                return BadRequest();
            }

            _context.Entry(manutenco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManutencoExists(id))
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

        // POST: api/Manutencoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manutenco>> PostManutenco(Manutenco manutenco)
        {
            _context.Manutencoes.Add(manutenco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManutenco", new { id = manutenco.IdManutencao }, manutenco);
        }

        // DELETE: api/Manutencoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManutenco(int id)
        {
            var manutenco = await _context.Manutencoes.FindAsync(id);
            if (manutenco == null)
            {
                return NotFound();
            }

            _context.Manutencoes.Remove(manutenco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManutencoExists(int id)
        {
            return _context.Manutencoes.Any(e => e.IdManutencao == id);
        }
    }
}
