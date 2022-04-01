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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposVeiculosController : ControllerBase
    {
        private readonly LoggexContext _context;

        public TiposVeiculosController(LoggexContext context)
        {
            _context = context;
        }

        // GET: api/TiposVeiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposVeiculo>>> GetTiposVeiculos()
        {
            return await _context.TiposVeiculos.ToListAsync();
        }

        // GET: api/TiposVeiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposVeiculo>> GetTiposVeiculo(int id)
        {
            var tiposVeiculo = await _context.TiposVeiculos.FindAsync(id);

            if (tiposVeiculo == null)
            {
                return NotFound();
            }

            return tiposVeiculo;
        }

        // PUT: api/TiposVeiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposVeiculo(int id, TiposVeiculo tiposVeiculo)
        {
            if (id != tiposVeiculo.IdTipoVeiculo)
            {
                return BadRequest();
            }

            _context.Entry(tiposVeiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposVeiculoExists(id))
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

        // POST: api/TiposVeiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposVeiculo>> PostTiposVeiculo(TiposVeiculo tiposVeiculo)
        {
            _context.TiposVeiculos.Add(tiposVeiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposVeiculo", new { id = tiposVeiculo.IdTipoVeiculo }, tiposVeiculo);
        }

        // DELETE: api/TiposVeiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposVeiculo(int id)
        {
            var tiposVeiculo = await _context.TiposVeiculos.FindAsync(id);
            if (tiposVeiculo == null)
            {
                return NotFound();
            }

            _context.TiposVeiculos.Remove(tiposVeiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposVeiculoExists(int id)
        {
            return _context.TiposVeiculos.Any(e => e.IdTipoVeiculo == id);
        }
    }
}
