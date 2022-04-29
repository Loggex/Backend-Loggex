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
using LoggexWebAPI.Interfaces;
using LoggexWebAPI.Repositories;

namespace LoggexWebAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManutencoesController : ControllerBase
    {
        private readonly LoggexContext _context;
        private IManutencaoRepository _manuRepository { get; set; }

        public ManutencoesController(LoggexContext context)
        {
            _context = context;
            _manuRepository = new ManutencaoRepository();

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
        public IActionResult Atualizar(int id, Manutenco manuUPDT)
        {
            try
            {
                Manutenco teste = _manuRepository.BuscarPorID(id);
                if (teste != null)
                {
                    _manuRepository.Atualizar(id, manuUPDT);

                    return StatusCode(204);
                }

                return NotFound("A manutencao não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
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
